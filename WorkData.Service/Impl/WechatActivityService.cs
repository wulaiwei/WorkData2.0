// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.Service 
// 文件名：WechatActivityService.cs
// 创建标识：吴来伟 2016-12-27
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using System.Linq.Dynamic;
using WorkData.EF.Domain.Entity;
using WorkData.EF.Domain.Entity.MySql;
using WorkData.EF.Domain.Entity.Wechat;
using WorkData.Infrastructure.IUnitOfWorks;
using WorkData.Respository.Repositories;
using WorkData.Respository.SqlHelper;
using WorkData.Service.Interface;
using WorkData.Util.Entity;

namespace WorkData.Service.Impl
{
    public class WechatActivityService: IWechatActivityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WechatActivityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 返回列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetDataTable(WechatActivity wechatActivity)
        {
            using (_unitOfWork)
            {
                var db = _unitOfWork.GetDb(wechatActivity.ConStrName);
 
                var proxy = SqlHelperBusiness.CreateProxy(db.Database, wechatActivity);

                return proxy.Query(db.Database,wechatActivity.Sql);
                 
            }
        }

        public void Add()
        {
            using (_unitOfWork)
            {
                var repository1 = _unitOfWork.Repository<EF.Domain.Entity.URTU.UrtuUser>("text");
                var repository2 = _unitOfWork.Repository<Role>();
                var repository3 = _unitOfWork.Repository<ActivityCategory>("Oracle");
                var repository4 = _unitOfWork.Repository<MySqlUser>("MySql");


                var user = new EF.Domain.Entity.URTU.UrtuUser {UserName = "cete"};

                var role = new Role() {Code="sfds",Name="sdfsd",Status=true };

                var activityCategory = new ActivityCategory()
                {
                    ActionCode="22",Code="sdfs",Name="sdfsdfs"
                };

                var mySqlUser = new MySqlUser() {Name="手动阀手动阀" };

                repository1.Add(user);
                repository2.Add(role);
                repository3.Add(activityCategory);
                repository4.Add(mySqlUser);

                _unitOfWork.Commit();

            }
        }
    }
}