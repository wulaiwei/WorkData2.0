using System.Collections.Generic;

namespace WorkData.Dto.Entity
{
    /// <summary>
    /// ģ���ֶ�
    /// </summary>
    public sealed class ModelFieldDto
    {
        public ModelFieldDto()
        {
            this.Models = new List<ModelDto>();
        }

        /// <summary>
        /// ģ���ֶ�ID
        /// </summary>
        public int ModelFieldId { get; set; }

        /// <summary>
        ///�ֶ�����
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �ֶδ���
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// �ֶ�����
        /// </summary>
        public string ControlType { get; set; }

        /// <summary>
        /// Ĭ��ֵ
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// ��֤��ʾ��Ϣ
        /// </summary>
        public string ValidTipMsg { get; set; }

        /// <summary>
        /// ������ʽ
        /// </summary>
        public string ValidPattern { get; set; }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string ValidErrorMsg { get; set; }

        /// <summary>
        /// �ֶ�����
        /// </summary>
        public int FieldType { get; set; }

        /// <summary>
        /// �Ƿ�ϵͳ�ֶ�
        /// </summary>
        public bool? IsSystemField { get; set; }


        /// <summary>
        /// ѡ�
        /// </summary>
        public string ItemOption { get; set; }

        /// <summary>
        /// ģ������
        /// </summary>
        public string HtmlTemplate { get; set; }

        /// <summary>
        /// ״̬
        /// </summary>
        public bool Status { get; set; }

        #region ���
        public ICollection<ModelDto> Models { get; set; }
        #endregion
    }
}
