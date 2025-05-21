using System.Linq.Expressions;

namespace Domain.Contracts;

public abstract class Specifications<T> where T : class
{
    public Expression<Func<T,bool>>? Criteria { get; } // where
    public List<Expression<Func<T,object>>> Includes { get; } = new(); // Include
    public Expression<Func<T, object>>? OrderBy { get; private set; }
    public Expression<Func<T, object>>? OrderByDescending { get; private set; }
    public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPaginated { get; private set; }
    protected Specifications(Expression<Func<T,bool>>? criteria)
    {
        Criteria = criteria;
    }

    protected void AddInclude(Expression<Func<T, object>> includeExpression) => Includes.Add(includeExpression);
    protected void SetOrderyBy(Expression<Func<T, object>> orderByExpression) => OrderBy = orderByExpression;
    protected void SetOrderByDescending(Expression<Func<T, object>> orderByExpression) => OrderByDescending = orderByExpression;

    protected void ApplyPagination(int skip, int take)
    {
        IsPaginated = true;
        Take = take;
        Skip = (skip-1)*take;
    }

}