using System;
using System.Collections.Generic;

namespace WorkData.Dto.Entity
{
    public sealed partial class UserDto
    {
        public UserDto()
        {
            //this.Resources = new List<PrivilegeDto>();
            this.Roles = new List<RoleDto>();
        }

        /// <summary>
        ///�û�ID
        /// </summary>

        public int UserId { get; set; }

        /// <summary>
        ///��¼��
        /// </summary>

        public string LoginName { get; set; }

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsLock { get; set; }

        /// <summary>
        /// ��ֵ
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        ///����
        /// </summary>

        public string Password { get; set; }

        /// <summary>
        ///��ʵ����
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        ///�ֻ�
        /// </summary>

        public string CellPhone { get; set; }

        /// <summary>
        ///����
        /// </summary>

        public string Email { get; set; }

        /// <summary>
        ///��ַ
        /// </summary>

        public string Address { get; set; }

        /// <summary>
        ///Qq
        /// </summary>

        public string Qq { get; set; }

        /// <summary>
        ///΢��
        /// </summary>

        public string WeiChatNumber { get; set; }

        /// <summary>
        ///����ʱ��
        /// </summary>

        public DateTime? AddTime { get; set; }

        #region ���
        //public ICollection<PrivilegeDto> Resources { get; set; }
        public ICollection<RoleDto> Roles { get; set; }

        #endregion ���
    }
}