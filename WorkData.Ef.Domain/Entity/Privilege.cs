using System.Collections.Generic;

namespace WorkData.EF.Domain.Entity
{
    public sealed class Privilege
    {
        public Privilege()
        {
            Roles = new List<Role>();
            //Users = new List<User>();
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

        public Operation Operation { get; set; }
        public Resource Resource { get; set; }
        public ICollection<Role> Roles { get; set; }
        //public ICollection<User> Users { get; set; }

        #endregion ���
    }
}