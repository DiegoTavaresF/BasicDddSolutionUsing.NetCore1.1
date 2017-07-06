using Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTestApplication.Base
{
    public static class ContextMock
    {
        public static Mock<ContextBase> CreateMockForDbContext<TEntity>(Mock<DbSet<TEntity>> mockSet)
            where TEntity : class
        {
            var mockContext = new Mock<ContextBase>();
            mockContext.Setup(c => c.Set<TEntity>()).Returns(mockSet.Object);

            return mockContext;
        }

        public static Mock<DbSet<T>> CreateMockForDbSet<T>() where T : class
        {
            return new Mock<DbSet<T>>();
        }

        public static Mock<DbSet<T>> SetupForQueryOn<T>(this Mock<DbSet<T>> dbSet, List<T> table) where T : class
        {
            dbSet.As<IQueryable<T>>().Setup(q => q.Provider).Returns(() => table.AsQueryable().Provider);
            dbSet.As<IQueryable<T>>().Setup(q => q.Expression).Returns(() => table.AsQueryable().Expression);
            dbSet.As<IQueryable<T>>().Setup(q => q.ElementType).Returns(() => table.AsQueryable().ElementType);
            dbSet.As<IQueryable<T>>().Setup(q => q.GetEnumerator()).Returns(() => table.AsQueryable().GetEnumerator());

            return dbSet;
        }
    }
}