﻿// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.BLL 
// 文件名：BllModule.cs
// 创建标识：吴来伟 2016-10-28
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using Autofac;
using WorkData.BLL.Impl;
using WorkData.BLL.Interface;

namespace WorkData.BLL.AutoModules
{
    public class BllModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ResourceBll>().As<IResourceBll>();
            builder.RegisterType<OperationBll>().As<IOperationBll>();
            builder.RegisterType<RoleBll>().As<IRoleBll>();
            builder.RegisterType<UserBll>().As<IUserBll>();

            builder.RegisterType<ModelBll>().As<IModelBll>();
            builder.RegisterType<ModelFieldBll>().As<IModelFieldBll>();
            builder.RegisterType<CategoryBll>().As<ICategoryBll>();
            builder.RegisterType<ContentBll>().As<IContentBll>();

            builder.RegisterType<WechatActivityBll>().As<IWechatActivityBll>();

        }
    }
}