// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。 
// 项目名：WorkData.Infrastructure 
// 文件名：IEfContextFactory.cs
// 创建标识：吴来伟 2016-12-22
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data.Entity;

namespace WorkData.Respository.UnitOfWorks
{
    public interface IEfContextFactory
    {
        DbContext GetCurrentDbContext(Dictionary<string, DbContext> dic);

        DbContext GetCurrentDbContext(string conString, Dictionary<string, DbContext> dic);

        //Dictionary<string, DbContextTransaction> GetTransaction();

        //void ClearTransaction();
    }
}