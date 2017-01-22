using System.Collections.Generic;


namespace WorkData.Dto.Entity
{
    public sealed class ResourceDto
    {
        public ResourceDto()
        {
            this.Operations = new List<OperationDto>();
            this.Roles = new List<RoleDto>();
        }

        /// <summary>
        ///��ԴID
        /// </summary>

        public int ResourceId { get; set; }

        /// <summary>
        ///����ID
        /// </summary>

        public int? ParentId { get; set; }

        /// <summary>
        ///��Դ����
        /// </summary>

        public string ResourceName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///��Դ����
        /// </summary>
        public string ResourceUrl { get; set; }

        /// <summary>
        ///����
        /// </summary>

        public int Layer { get; set; }

        /// <summary>
        ///�Ƿ�����
        /// </summary>

        public bool IsLock { get; set; }

        /// <summary>
        ///��ԴͼƬ
        /// </summary>

        public string ResourceImg { get; set; }

        /// <summary>
        ///����
        /// </summary>

        public int Sort { get; set; }

        /// <summary>
        ///�Ƿ����Ӽ�
        /// </summary>

        public bool HasLevel { get; set; }

        /// <summary>
        /// ����������
        /// </summary>
        public string ControllerName { get; set; }

        #region ���

        public ICollection<OperationDto> Operations { get; set; }

        public ICollection<RoleDto> Roles { get; set; }
        #endregion ���
    }
}