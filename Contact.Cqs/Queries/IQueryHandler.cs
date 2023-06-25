namespace Contact.Cqs.Queries;

public interface IQueryHandler<TQuery, TResult> where TQuery : class, IQuery<TResult>
{
    TResult Execute(TQuery query);
}
