using System;
using System.Data;
using Autofac;
using System.Web.Mvc;
using WorkData.Dto.Entity;
using WorkData.BLL.Interface;
using WorkData.Util;
using WorkData.Util.Entity;
using WorkData.Web.HtmlFactory;
using System.Linq;
using System.Reflection;
using WorkData.Util.Enum;
using WorkData.Web;

namespace WorkData.Web.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IOperationBll _operationBll;
        private readonly IResourceBll _resourceBll;
        private readonly IRoleBll _roleBll;
        private readonly IWechatActivityBll _wechatActivityBll;
        public DefaultController(IOperationBll operationBll, IResourceBll resourceBll, IRoleBll roleBll, IWechatActivityBll wechatActivityBll)
        {
            _operationBll = operationBll;
            _resourceBll = resourceBll;
            _roleBll = roleBll;
            _wechatActivityBll = wechatActivityBll;
        }

        //测试
        // GET: Default
        public ActionResult Index()
        {
            var info = new WechatActivity()
            {
                ConStrName = "Oracle",
                Sql = @"select 
                    wechatUser.NICK_NAME,
                    wechatUser.MOBILE_NO,
                    activity.ACTIVITY_NAME,
                    activity.CREATION_TIME
                 from WX_WECHAT_USER 
                 wechatUser 
                 join
                 (
                select * from
                 WX_USER_ACTIVITY_LOG where ID in(select min(ID) 
                from WX_USER_ACTIVITY_LOG group by USER_ID,ACTIVITY_NAME)
                 and ACTIVITY_NAME='遂宁-平安夜+圣诞节(3元2个G)' 
                 order by ID desc
                 ) activity on wechatUser.ID =activity.USER_ID",
                DataTable = new DataTable()
            };
            _wechatActivityBll.GetDataTable(info);

            var info1 = new WechatActivity()
            {
                ConStrName = "text",
                Sql = @"select * from text",
                DataTable = new DataTable()
            };
            _wechatActivityBll.GetDataTable(info1);

            var info2 = new WechatActivity()
            {
                ConStrName = "Oracle",
                Sql = @"select * from WX_USER_ACTIVITY_LOG",
                DataTable = new DataTable()
            };
            _wechatActivityBll.GetDataTable(info2);

            var info3 = new WechatActivity()
            {
                ConStrName = "text",
                Sql = @"select * from [dbo].[USER]",
                DataTable = new DataTable()
            };
            _wechatActivityBll.GetDataTable(info3);

            var info4 = new WechatActivity()
            {
                ConStrName = "MySql",
                Sql = @"select * from USER",
                DataTable = new DataTable()
            };
            _wechatActivityBll.GetDataTable(info4);

            //_wechatActivityBll.Add();

            //LoggerHelper.BusinessLog.Error("BusinessLog");
            //LoggerHelper.SystemLog.Error("SystemLog");
            //var info = AssemblyHelper.LoadAction("WorkData.Web");

            //var list = _resourceBll.GetList();
            //var infoList = list.Select(x => new AuthConfig
            //{
            //    ControllerName = x.ControllerName,
            //    ResourceId = x.ResourceId,
            //    ResourceUrl = x.ResourceUrl,
            //    Roles = ""
            //}).ToList();
            //AuthConfigXmlHelper.CreateAuthConfigXml(infoList, info, Api.PhysicsUrl + "/Config/AuthConfig.xml");

            //AuthConfigXmlHelper.UpdateConfig(Api.PhysicsUrl + "/Config/AuthConfig.xml", info);


            //var assembly = Assembly.Load("WorkData.Web");    //加载程序集

            return View();
        }
    }
}