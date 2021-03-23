using AutoMapper;
using MNV.Core.Database;
using MNV.Core.Providers;
using MNV.Domain.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MNV.Queries
{
    public abstract class QueryHandler
    {
        protected readonly IDataContext _dataContext;
        protected readonly IMapper _mapper;
        protected readonly ICurrentUserProvider _currentUserProvider;
        public QueryHandler(IDataContext dataContext, IMapper mapper, ICurrentUserProvider currentUserProvider)
        {
            _dataContext = dataContext ?? throw new ArgumentException(nameof(dataContext));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _currentUserProvider = currentUserProvider ?? throw new ArgumentException(nameof(currentUserProvider));
        }

        protected IQueryable<T> GetPaginated<T>(IQueryable<T> collection, PagingModel paging)
        {
            return collection.Skip((paging.Page - 1) * paging.PageSize).Take(paging.PageSize);
        }

        protected IQueryable<T> GetSorted<T>(IQueryable<T> collection, SortModel sorting)
        {
            if (sorting is null)
                return collection;

            if (sorting.SortName is null)
            {
                return collection;
            }

            var type = typeof(T);
            var sortFieldType = type.GetProperty(sorting.SortName)?.PropertyType;
            if (sortFieldType == null)
            {
                return collection;
            }

            if (sortFieldType == typeof(DateTime))
            {
                return sorting.SortAscending ?
                    collection.OrderBy(CreateSelectorExpression<T, DateTime>(sorting.SortName)) :
                    collection.OrderByDescending(CreateSelectorExpression<T, DateTime>(sorting.SortName));
            }

            if (sortFieldType == typeof(Double))
            {
                return sorting.SortAscending ?
                    collection.OrderBy(CreateSelectorExpression<T, Double>(sorting.SortName)) :
                    collection.OrderByDescending(CreateSelectorExpression<T, Double>(sorting.SortName));
            }

            return sorting.SortAscending ?
                collection.OrderBy(CreateSelectorExpression<T, string>(sorting.SortName)) :
                collection.OrderByDescending(CreateSelectorExpression<T, string>(sorting.SortName));
        }

        #region Private Method(s)
        private string GetType<T>(string name)
        {
            var type2 = typeof(T).GetProperty(name);
            if (type2 != null)
            {
                return type2.PropertyType.Name;
            }

            return null;
        }

        private Expression<Func<T, K>> CreateSelectorExpression<T, K>(string propertyName)
        {
            var paramterExpression = Expression.Parameter(typeof(T));
            return (Expression<Func<T, K>>)Expression.Lambda(Expression.PropertyOrField(paramterExpression, propertyName),
                                                                    paramterExpression);
        }
        #endregion
    }
}
