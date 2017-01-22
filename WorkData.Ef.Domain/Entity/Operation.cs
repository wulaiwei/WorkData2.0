using System.Collections.Generic;

namespace WorkData.EF.Domain.Entity
{
    public sealed class Operation
    {
        public Operation()
        {
            this.Resources = new List<Resource>();
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
        public string  Class { get; set; }

        /// <summary>
        /// Html Id
        /// </summary>
        public string  Id { get; set; }

        /// <summary>
        /// �¼�
        /// </summary>
        public string  OnClick { get; set; }

        /// <summary>
        /// ��ʽ
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public int? OperationCategory { get; set; }
        #region ���

        public ICollection<Resource> Resources { get; set; }

        #endregion ���
    }
}