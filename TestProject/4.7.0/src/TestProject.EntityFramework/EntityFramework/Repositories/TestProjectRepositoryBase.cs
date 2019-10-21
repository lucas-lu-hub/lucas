using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace TestProject.EntityFramework.Repositories
{
    public abstract class TestProjectRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<TestProjectDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected TestProjectRepositoryBase(IDbContextProvider<TestProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class TestProjectRepositoryBase<TEntity> : TestProjectRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected TestProjectRepositoryBase(IDbContextProvider<TestProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
