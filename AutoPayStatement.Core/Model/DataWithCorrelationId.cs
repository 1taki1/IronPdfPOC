namespace AutoPayStatement.Core.Model;

public class DataWithCorrelationId<T>(string correlationId, T data)
{
    public string CorrelationId { get; } = correlationId;

    public T Data { get; } = data;

    public static DataWithCorrelationId<T> Create(string correlationId, T data) => new(correlationId, data);
}
