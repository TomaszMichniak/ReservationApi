using Microsoft.EntityFrameworkCore;
using ReservationApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApi.Infrastructure.Specification
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            query = specification.Criteria.Aggregate(query, (current, criteria) => current.Where(criteria));

            query = specification.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));
            return query;
        }
    }
}
