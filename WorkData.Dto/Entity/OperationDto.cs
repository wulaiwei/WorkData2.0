using System.Collections.Generic;

namespace WorkData.Dto.Entity
{
    public sealed class OperationDto
    {
        public OperationDto()
        {
            this.Resources = new List<ResourceDto>();
        }

        /// <summary>
        ///����ID
        /// </summary>

        public int OperationId { get; set; }

        /// <summary>
        ///��������
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        ///��������
        /// </summary>

        public string Code { get; set; }

        /// <summary>
        ///״̬
        /// </summary>

        public bool Status { get; set; }

        /// <summary>
        /// Html Class
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// Html Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// �¼�
        /// </summary>
        public string OnClick { get; set; }

        /// <summary>
        /// ��ʽ
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public int? OperationCategory { get; set; }
        #region ���

        public ICollection<ResourceDto> Resources { get; set; }

        #endregion ���
    }
}