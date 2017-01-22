using System;

namespace WorkData.EF.Domain.Entity
{
    /// <summary>
    /// ������������
    /// </summary>
    public sealed class ContentDoubleField
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ContentDoubleFieldId { get; set; }

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
        public double? FieldValue { get; set; }

        #region ���
        public Content Content { get; set; }
        #endregion
    }
}
