namespace AnimalMatcher.Data.Repository.Interfaces
{
    using AnimalMatcher.Data.Specifications.Interfaces;
    using System.Collections.Generic;

    public interface IGenericRepository<T>
    {
        void Add(T entity);

        IEnumerable<T> All();

        IEnumerable<T> List(ISpecification<T> specification);

        void Delete(T entity);

        T GetById<TIdType>(TIdType id);

        void Save();
    }
}
