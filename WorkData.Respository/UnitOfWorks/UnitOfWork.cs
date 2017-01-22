// ------------------------------------------------------------------------------
// Copyright  成都联宇创新科技有限公司 版权所有。
// 项目名：UnitWork.Repository
// 文件名：EfUnitWork.cs
// 创建标识：laiwei wu  2016-08-29 16:42
// 创建描述：
//
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using WorkData.Infrastructure.IRepositories;
using WorkData.Infrastructure.ITransactions;
using WorkData.Infrastructure.IUnitOfWorks;
using WorkData.Respository.Repositories;
using WorkData.Respository.Transactions;

namespace WorkData.Respository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _db;

        private readonly IEfContextFactory _efContextFactory;
        public Dictionary<string, DbContext> InitializedDbContexts;


        public UnitOfWork(IEfContextFactory efContextFactory)
        {
            _efContextFactory = efContextFactory;
            InitializedDbContexts = new Dictionary<string, DbContext>();
        }

        public Dictionary<Type, object> Repositories = new Dictionary<Type, object>();

        public IRepository<T> Repository<T>() where T : class
        {
            _db = _efContextFactory.GetCurrentDbContext(InitializedDbContexts);

            IRepository<T> repo = new BaseRepository<T>(_db);
            return repo;
        }

        /// <summary>
        /// 切换数据库连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conStringName"></param>
        /// <returns></returns>
        public IRepository<T> Repository<T>(string conStringName) where T : class
        {
            _db = _efContextFactory.GetCurrentDbContext(conStringName, InitializedDbContexts);

            IRepository<T> repo = new BaseRepository<T>(_db);
            return repo;
        }

        #region 事务管理

        public void Commit()
        {
            foreach (var dbContext in InitializedDbContexts.Values)
            {
                using (var tran = BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        dbContext.SaveChanges();
                        tran.Commit();
                        tran.Dispose();
                    }
                    catch
                    {
                        tran.RollBack();
                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// 获取数据上下文
        /// </summary>
        /// <param name="conStringName"></param>
        /// <returns></returns>
        public DbContext GetDb(string conStringName)
        {
            return _efContextFactory.GetCurrentDbContext(conStringName, InitializedDbContexts);
        }

        #endregion 事务管理

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db?.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ITransaction BeginTransaction(IsolationLevel level)
        {
            var trans = _db.Database.BeginTransaction(level);
            return new EfTransaction(trans);
        }

        private static TValue GetValueOrDefault<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : default(TValue);
        }
    }
}