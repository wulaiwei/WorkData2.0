﻿using Autofac;
using WorkData.Respository.AutoModules;
using WorkData.Service.Impl;
using WorkData.Service.Interface;

namespace WorkData.Service.AutoModules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<EntityFrameworkModule>();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<OperationService>().As<IOperationService>();
            builder.RegisterType<ResourceService>().As<IResourceService>();

            builder.RegisterType<ModelService>().As<IModelService>();
            builder.RegisterType<ModelFieldService>().As<IModelFieldService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<ContentService>().As<IContentService>();
            builder.RegisterType<WechatActivityService>().As<IWechatActivityService>();
        }
    }
}