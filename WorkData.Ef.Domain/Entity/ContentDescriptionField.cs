namespace WorkData.EF.Domain.Entity
{
    /// <summary>
    /// ��������
    /// </summary>
    public sealed class ContentDescriptionField
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ContentDescriptionFieldId { get; set; }
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
        public string FieldValue { get; set; }

        #region ���
        public Content Content { get; set; }
        #endregion
    }
}
