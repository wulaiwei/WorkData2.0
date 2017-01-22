using System.Collections.Generic;

namespace WorkData.Dto.Entity
{
    public sealed class PrivilegeDto
    {
        public PrivilegeDto()
        {
            this.Roles = new List<RoleDto>();
            //this.Users = new List<UserDto>();
        }

        /// <summary>
        ///Ȩ��ID
        /// </summary>

        public int PrivilegeId { get; set; }

        /// <summary>
        ///��ԴID
        /// </summary>

        public int ResourceId { get; set; }

        /// <summary>
        ///����ID
        /// </summary>

        public int OperationId { get; set; }

        #region ���

        public OperationDto Operation { get; set; }
        public ResourceDto Resource { get; set; }
        public ICollection<RoleDto> Roles { get; set; }
        //public ICollection<UserDto> Users { get; set; }

        #endregion ���
    }
}