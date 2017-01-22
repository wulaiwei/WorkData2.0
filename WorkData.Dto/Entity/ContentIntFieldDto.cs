namespace WorkData.Dto.Entity
{
    /// <summary>
    /// ��������
    /// </summary>
    public sealed class ContentIntFieldDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ContentIntFieldId { get; set; }

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
        public int? FieldValue { get; set; }

        #region ���
        public ContentDto Content { get; set; }
        #endregion
    }
}
