namespace WorkData.Dto.Entity
{
    /// <summary>
    /// ��������
    /// </summary>
    public sealed class ContentTextFieldDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ContentTextFieldId { get; set; }

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
