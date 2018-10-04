namespace AnimalMatcher.Data.Repository
{
    using AnimalMatcher.Data.Repository.Interfaces;
    using AnimalMatcher.Data.Specifications.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext dbContext;

        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(dbContext));

        }

        public void Add(T entity) => this.dbContext.Set<T>().Add(entity);

        public IEnumerable<T> All() => this.dbContext.Set<T>().AsEnumerable();

        public IEnumerable<T> List(ISpecification<T> specification)
        {
            var queryableResultWithIncludes = specification.Includes
                .Aggregate(dbContext.Set<T>().AsQueryable(),
                    (dbSetQueryable, includeExpression) => dbSetQueryable.Include(includeExpression));
            
            if(specification.FilterCriteria == null)
            {
                return queryableResultWithIncludes.AsEnumerable();
            }

            var enumerableQueryResult = queryableResultWithIncludes
                            .Where(specification.FilterCriteria)
                            .ToList();

            return enumerableQueryResult;
        }

        public void Delete(T entity) => this.dbContext.Set<T>().Remove(entity);

        public T GetById<TIdType>(TIdType id) => this.dbContext.Set<T>().Find(id);

        public void Save() => this.dbContext.SaveChanges();
    }
}
