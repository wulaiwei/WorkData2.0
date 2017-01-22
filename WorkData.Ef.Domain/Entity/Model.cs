using System;
using System.Collections.Generic;

namespace WorkData.EF.Domain.Entity
{
    /// <summary>
    /// ģ��
    /// </summary>
    public sealed class Model
    {
        public Model()
        {
            this.Categorys = new List<Category>();
            this.Contents = new List<Content>();
            this.ModelFields = new List<ModelField>();
        }

        /// <summary>
        /// ģ��ID
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// ģ������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ģ�ʹ���
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// ״̬
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Description { get; set; }

        #region ���
        public ICollection<Category> Categorys { get; set; }
        public ICollection<Content> Contents { get; set; }
        public ICollection<ModelField> ModelFields { get; set; } 
        #endregion
    }
}
