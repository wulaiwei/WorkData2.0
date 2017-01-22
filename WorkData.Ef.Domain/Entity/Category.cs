using System;
using System.Collections.Generic;

namespace WorkData.EF.Domain.Entity
{
    /// <summary>
    /// ��Ŀ��
    /// </summary>
    public sealed class Category
    {
        public Category()
        {
            this.Contents = new List<Content>();
        }

        /// <summary>
        /// ��ĿID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        ///����ID
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// ģ��ID
        /// </summary>
        public int? ModelId { get; set; }

        /// <summary>
        /// ��Ŀ��
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// ״̬
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        ///����
        /// </summary>
        public int Layer { get; set; }

        /// <summary>
        ///�Ƿ����Ӽ�
        /// </summary>
        public bool HasLevel { get; set; }

        /// <summary>
        ///����
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// ��ģ��
        /// </summary>
        public string FormTemplate { get; set; }

        /// <summary>
        /// ��ģ��JSON
        /// </summary>
        public string FormJson { get; set; }

        /// <summary>
        /// �б�ģ��JSON
        /// </summary>
        public string ListJson { get; set; }


        /// <summary>
        /// �б�ͷ��
        /// </summary>
        public string ListHead { get; set; }

        /// <summary>
        /// �б�ģ��
        /// </summary>
        public string ListTempalte { get; set; }

        #region ���
        public Model Model { get; set; }
        public ICollection<Content> Contents { get; set; } 
        #endregion
    }
}
