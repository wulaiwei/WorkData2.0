namespace WorkData.Dto.Entity
{
    /// <summary>
    /// ��������
    /// </summary>
    public sealed class ContentDescriptionFieldDto
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
        public ContentDto Content { get; set; }
        #endregion
    }
}
