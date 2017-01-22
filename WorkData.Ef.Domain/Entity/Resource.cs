using System.Collections.Generic;
using Newtonsoft.Json;

namespace WorkData.EF.Domain.Entity
{
    public sealed class Resource
    {
        public Resource()
        {
            this.Operations = new List<Operation>();
            this.Roles = new List<Role>();
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
        /// ��Դ����
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

        [JsonIgnore]
        public ICollection<Operation> Operations { get; set; }

        [JsonIgnore]
        public ICollection<Role> Roles { get; set; }

        #endregion ���
    }
}