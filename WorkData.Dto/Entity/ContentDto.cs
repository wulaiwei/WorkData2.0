using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WorkData.EF.Domain.Entity;

namespace WorkData.Dto.Entity
{
    /// <summary>
    /// ���ݱ�
    /// </summary>
    public class ContentDto
    {
        public ContentDto()
        {
            this.ContentDescriptionFields = new List<ContentDescriptionField>();
            this.ContentDoubleFields = new List<ContentDoubleField>();
            this.ContentIntFields = new List<ContentIntField>();
            this.ContentStringFields = new List<ContentStringField>();
            this.ContentTextFields = new List<ContentTextField>();
            this.ContentTimeFields = new List<ContentTimeField>();
        }

        /// <summary>
        /// ����ID
        /// </summary>
        public int ContentId { get; set; }

        /// <summary>
        /// ģ��ID
        /// </summary>
        public int? ModelId { get; set; }

        /// <summary>
        /// ��ĿID
        /// </summary>
        public int? CategoryId { get; set; }


        #region ���
        [JsonIgnore]
        public ICollection<ContentIntField> ContentIntFields { get; set; }

        [JsonIgnore]
        public ICollection<ContentTimeField> ContentTimeFields { get; set; }

        [JsonIgnore]
        public ICollection<ContentDoubleField> ContentDoubleFields { get; set; }

        [JsonIgnore]
        public ICollection<ContentStringField> ContentStringFields { get; set; }

        [JsonIgnore]
        public ICollection<ContentTextField> ContentTextFields { get; set; }

        [JsonIgnore]
        public ICollection<ContentDescriptionField> ContentDescriptionFields { get; set; }

        [JsonIgnore]
        public Model Model { get; set; }

        [JsonIgnore]
        public CategoryDto Category { get; set; }

        #endregion

        /// <summary>
        /// ��̬����
        /// </summary>
        public ContentValue ContentValue { get; set; }
    }
}
