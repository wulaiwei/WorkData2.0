using System.Collections.Generic;
using WorkData.EF.Domain.Entity;

namespace WorkData.Dto.Entity
{
    /// <summary>
    /// ģ��
    /// </summary>
    public sealed class ModelDto
    {
        public ModelDto()
        {
            this.Categorys = new List<CategoryDto>();
            this.Contents = new List<ContentDto>();
            this.ModelFields = new List<ModelFieldDto>();
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
        public ICollection<CategoryDto> Categorys { get; set; }
        public ICollection<ContentDto> Contents { get; set; }
        public ICollection<ModelFieldDto> ModelFields { get; set; } 
        #endregion
    }
}
