using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace JunDemo.EntityFramework.Repositories
{
    public abstract class JunDemoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<JunDemoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected JunDemoRepositoryBase(IDbContextProvider<JunDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class JunDemoRepositoryBase<TEntity> : JunDemoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected JunDemoRepositoryBase(IDbContextProvider<JunDemoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
