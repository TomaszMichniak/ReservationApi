using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Domain.Specification
{
    public class Specification<T> : ISpecification<T> where T : class
    {
        private readonly List<Expression<Func<T, bool>>> _criteria = new List<Expression<Func<T, bool>>>();
        private readonly List<Expression<Func<T, object>>> _includes = new List<Expression<Func<T, object>>>();
       
        public Expression<Func<T, object>>? OrderByDescending { get; private set; }
        public Expression<Func<T, object>>? OrderBy {get; private set; }


        public List<Expression<Func<T, bool>>> Criteria => _criteria;
        public List<Expression<Func<T, object>>> Includes => _includes;



        public void SetOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        public void SetOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
    }


}

