namespace AnimalMatcher.Specifications
{
    using AnimalMatcher.Data.Specifications.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq.Expressions;

    public class Specification<T> : ISpecification<T>
    {
        private readonly List<Expression<Func<T, object>>> includes;

        public Specification()
            :this(null)
        { }

        public Specification(Expression<Func<T, bool>> filterCriteria)
        {

            this.FilterCriteria = filterCriteria;
            this.includes = new List<Expression<Func<T, object>>>();
        }

        public Expression<Func<T, bool>> FilterCriteria { get; }

        public IReadOnlyCollection<Expression<Func<T, object>>> Includes
        {
            get
            {
                return this.includes.AsReadOnly();
            }
        }

        public void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            this.includes.Add(includeExpression);
        }
    }
}
