using System.Collections.Generic;

namespace WorkData.EF.Domain.Entity
{
    public sealed class Role
    {
        public Role()
        {
            //this.Resources = new List<Privilege>();
            this.Users = new List<User>();
            this.Resources = new List<Resource>();
        }

        /// <summary>
        ///��ɫID
        /// </summary>

        public int RoleId { get; set; }

        /// <summary>
        ///��ɫ����
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        ///��ɫ����
        /// </summary>

        public string Code { get; set; }

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool Status { get; set; }

        #region ���

        //public ICollection<Privilege> Resources { get; set; }
        public ICollection<User> Users { get; set; }

        public ICollection<Resource> Resources { get; set; }

        #endregion ���
    }
}