using System;

namespace WorkData.EF.Domain.Entity
{
    /// <summary>
    /// ʱ�����ݱ�
    /// </summary>
    public sealed class ContentTimeField
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ContentTimeFieldId { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        public int? ContentId { get; set; }

        /// <summary>
        /// �ֶδ���
        /// </summary>
        public string FieldCode { get; set; }

        /// <summary>
        /// ֵ
        /// </summary>
        public DateTime? FieldValue { get; set; }

        #region ���
        public Content Content { get; set; } 
        #endregion
    }
}
