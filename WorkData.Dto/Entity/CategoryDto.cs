using System.Collections.Generic;

namespace WorkData.Dto.Entity
{
    /// <summary>
    /// ��Ŀ��
    /// </summary>
    public sealed class CategoryDto
    {
        public CategoryDto()
        {
            this.Contents = new List<ContentDto>();
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
        ///����
        /// </summary>
        public int Layer { get; set; }

        /// <summary>
        /// ״̬
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        ///����
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        ///�Ƿ����Ӽ�
        /// </summary>
        public bool HasLevel { get; set; }

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
        public ModelDto Model { get; set; }
        public ICollection<ContentDto> Contents { get; set; } 
        #endregion
    }
}
