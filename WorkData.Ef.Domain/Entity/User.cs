using System;
using System.Collections.Generic;

namespace WorkData.EF.Domain.Entity
{
    public sealed class User
    {
        public User()
        {
            //this.Resources = new List<Privilege>();
            this.Roles = new List<Role>();
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
        ///����
        /// </summary>

        public string Password { get; set; }

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsLock { get; set; }

        /// <summary>
        /// ��ֵ
        /// </summary>
        public string Salt { get; set; }

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
        //public ICollection<Privilege> Resources { get; set; }
        public ICollection<Role> Roles { get; set; }

        #endregion ���
    }
}