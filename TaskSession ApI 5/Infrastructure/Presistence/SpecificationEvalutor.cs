using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Presistence;

public static class SpecificationEvalutor
{
    public static IQueryable<T> GetQuery<T>(IQueryable<T> baseInputOfQuery,Specifications<T> specifications) where T: class
    {
        var query = baseInputOfQuery;
        if (specifications.Criteria != null) query = query.Where(specifications.Criteria);
        // foreach (var item in specifications.Includes)
        // {
        //     query = query.Include(item);
        // }
        query=specifications.Includes.Aggregate(query,(curret, includeExpression) => curret.Include(includeExpression));
        if (specifications.OrderBy is not null) query = query.OrderBy(specifications.OrderBy);
        else if(specifications.OrderByDescending is not null) query = query.OrderByDescending(specifications.OrderByDescending);
        if(specifications.IsPaginated) query=query.Skip(specifications.Skip).Take(specifications.Take);
        return query;
    }
}