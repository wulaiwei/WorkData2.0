using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using WorkData.EF.Domain;
using WorkData.Respository.UnitOfWorks;


namespace WorkData.Respository
{
    public class EfContextFactory: IEfContextFactory
    {
        //private readonly Dictionary<string, DbContextTransaction> Transactions;
        //public EfContextFactory()
        //{
        //    Transactions = new Dictionary<string, DbContextTransaction>();
        //}

        //帮我们返回当前线程内的数据库上下文，如果当前线程内没有上下文，那么创建一个上下文，并保证
        //上线问实例在线程内部是唯一的
        public DbContext GetCurrentDbContext(string conStringName, Dictionary<string, DbContext> dic)
        {
            var dbContext = dic.ContainsKey(conStringName + "DbContext")? dic[conStringName + "DbContext"]:null;
            try
            {
                if (dbContext != null)
                {
                    var con = dbContext.Database.Connection;
                    return  dbContext;
                }
            }
            catch (Exception)
            {
                dic.Remove(conStringName + "DbContext");
                //CallContext.FreeNamedDataSlot(conStringName + "DbContext");
            }

            dbContext = string.IsNullOrEmpty(conStringName) 
                ? new DbEntity() 
                : new DbEntity(conStringName);

            //Pre-Generated Mapping Views（预生成映射视图）
            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
            var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
            mappingCollection.GenerateViews(new List<EdmSchemaError>());

            //我们在创建一个，放到数据槽中去
            dic.Add(conStringName+"DbContext", dbContext);

            return dbContext;
        }

        public DbContext GetCurrentDbContext(Dictionary<string, DbContext> dic)
        {
            return GetCurrentDbContext(null, dic);
        }


    }
}
