using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery; 

            // To add Inclueds to Db calls
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); 
            }

            // OrderBy for Sorting
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy); 
            }
            
            // OrderBy Desc for Sorting
            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending); 
            }           

            // Pagination
            if( spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take); 
            } 

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include)); 

            return query; 
        }
    }
}