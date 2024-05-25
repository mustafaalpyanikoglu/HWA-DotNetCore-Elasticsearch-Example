namespace RedisElasticDemo.Elasticsearch.Services;

/// <summary>
/// Interface for ElasticSearch service
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IElasticSearchService<T>
{
  /// <summary>
  /// Create a document in ElasticSearch
  /// </summary>
  /// <param name="document"></param>
  /// <returns></returns>
  Task<string> CreateDocumentAsync(T document);
  /// <summary>
  /// Delete a document in ElasticSearch
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  Task<string> DeleteDocumentAsync(int id);
  /// <summary>
  /// Update a document in ElasticSearch
  /// </summary>
  /// <param name="document"></param>
  /// <returns></returns>
  Task<string> UpdateDocumentAsync(T document);
  /// <summary>
  /// Get a document from ElasticSearch
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  Task<T> GetDocumentAsync(int id);
  /// <summary>
  /// Get all documents from ElasticSearch
  /// </summary>
  /// <returns></returns>
  Task<IEnumerable<T>> GetDocumentsAsync();
}
