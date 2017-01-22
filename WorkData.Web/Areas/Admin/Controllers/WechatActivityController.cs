using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkData.Util.Entity;

namespace WorkData.Web.Areas.Admin.Controllers
{
    public class WechatActivityController : Controller
    {


        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        public ActionResult Save()
        {
            var info2 = new WechatActivity()
            {
                ConStrName = Request[""],
                Sql = @"select * from WX_USER_ACTIVITY_LOG",
                DataTable = new DataTable()
                
            };

            return RedirectToAction("Index");
        }
    }
}