using System;
using Util.Datas;
using Util.Datas.Ef;
using Util.Domains;

namespace CoreAPI.Infrastructure.Data.EF.SQL {
    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class RepositoryBase<TEntity,TKey> : Repository<TEntity,TKey> where TEntity :class, IAggregateRoot<TKey> {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected RepositoryBase( IUnitOfWork unitOfWork )
            : base( unitOfWork ) {
            UnitOfWork = (CoreUnitOfWork)unitOfWork;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        protected new CoreUnitOfWork UnitOfWork { get; set; }
    }
    
    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity,Guid> where TEntity : class, IAggregateRoot<Guid> {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected RepositoryBase(IUnitOfWork unitOfWork )
            : base( unitOfWork ) {
        }
    }
}