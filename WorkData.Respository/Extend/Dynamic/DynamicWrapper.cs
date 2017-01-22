using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq;

//ReSharper disable CheckNamespace

namespace System.Linq.Dynamic
{
    public static class DynamicWrapper
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            var oItems = items as T[] ?? items.ToArray();
            var firstItem = oItems.FirstOrDefault();
            if (firstItem == null)
            {
                return new DataTable();
            }

            var oReturn = new DataTable(TypeDescriptor.GetClassName(firstItem));

            var properties = TypeDescriptor.GetProperties(firstItem);

            foreach (PropertyDescriptor property in properties)
            {
                oReturn.Columns.Add(property.Name, BaseType(property.PropertyType));
            }

            //#### Traverse the items
            foreach (var oItem in oItems)
            {
                //#### Collect the a_oValues for this loop
                var values = new object[properties.Count];

                //#### Traverse the a_oProperties, populating each a_oValues as we go
                for (var i = 0; i < properties.Count; i++)
                {
                    values[i] = properties[i].GetValue(oItem);
                }

                //#### .Add the .Row that represents the current a_oValues into our oReturn value
                oReturn.Rows.Add(values);
            }

            //#### Return the above determined oReturn value to the caller
            return oReturn;
        }

        internal static Type BaseType(Type type)
        {
            //#### If the passed type is valid, .IsValueType and is logicially nullable, .Get(its)UnderlyingType
            if (type != null &&
                type.IsValueType &&
                type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return Nullable.GetUnderlyingType(type);
            }

            //#### Else the passed type was null or was not logicially nullable, so simply return the passed type
            return type;
        }


        internal class DataRecordDynamicWrapper : DynamicObject, ICustomTypeDescriptor
        {
            private readonly IDataRecord _dataRecord;
            private PropertyDescriptorCollection _properties;

            public DataRecordDynamicWrapper(IDataRecord dataRecord)
            {
                _dataRecord = dataRecord;
            }

            AttributeCollection ICustomTypeDescriptor.GetAttributes()
            {
                return AttributeCollection.Empty;
            }

            string ICustomTypeDescriptor.GetClassName()
            {
                return _dataRecord.GetType().Name;
            }

            string ICustomTypeDescriptor.GetComponentName()
            {
                return _dataRecord.GetType().Name;
            }

            TypeConverter ICustomTypeDescriptor.GetConverter()
            {
                return new TypeConverter();
            }

            EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
            {
                return null;
            }

            PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
            {
                return null;
            }

            object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
            {
                throw new NotSupportedException();
            }

            EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
            {
                return EventDescriptorCollection.Empty;
            }

            EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
            {
                return EventDescriptorCollection.Empty;
            }

            PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
            {
                return _properties ?? (_properties = GenerateProperties());
            }

            PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
            {
                if (attributes != null && attributes.Length == 0)
                    return ((ICustomTypeDescriptor) this).GetProperties();

                return PropertyDescriptorCollection.Empty;
            }

            object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
            {
                return _dataRecord;
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                result = _dataRecord[binder.Name];
                return result != null;
            }

            private PropertyDescriptorCollection GenerateProperties()
            {
                var count = _dataRecord.FieldCount;
                var properties = new PropertyDescriptor[count];

                for (var i = 0; i < count; i++)
                {
                    properties[i] = new DataRecordProperty(i, _dataRecord.GetName(i), _dataRecord.GetFieldType(i));
                }

                return new PropertyDescriptorCollection(properties);
            }


            private sealed class DataRecordProperty : PropertyDescriptor
            {
                private static readonly Attribute[] NoAttributes = new Attribute[0];

                private readonly int _ordinal;

                public DataRecordProperty(int ordinal, string name, Type type)
                    : base(name, NoAttributes)
                {
                    _ordinal = ordinal;
                    PropertyType = type;
                }

                public override Type ComponentType => typeof(IDataRecord);

                public override bool IsReadOnly => true;

                public override Type PropertyType { get; }

                public override bool CanResetValue(object component)
                {
                    return false;
                }

                public override object GetValue(object component)
                {
                    var wrapper = (DataRecordDynamicWrapper) component;
                    return wrapper._dataRecord.GetValue(_ordinal);
                }

                public override void ResetValue(object component)
                {
                    throw new NotSupportedException();
                }

                public override void SetValue(object component, object value)
                {
                    throw new NotSupportedException();
                }

                public override bool ShouldSerializeValue(object component)
                {
                    return true;
                }
            }
        }
    }
}
