using Nest;

namespace RedisElasticDemo.Elasticsearch.Services;

/// <summary>
/// ElasticSearch service
/// </summary>
/// <typeparam name="T"></typeparam>
/// <remarks>
/// This class is not implemented yet
/// </remarks>
/// <seealso cref="IElasticSearchService{T}" />
/// <seealso cref="RedisElasticDemo.IElasticSearchService{T}" />
public class ElasticSearchService<T>(ElasticClient elasticClient) : IElasticSearchService<T>
  where T : class
{
  private readonly ElasticClient _elasticClient = elasticClient;

  /// <summary>
  /// Initializes a new instance of the <see cref="ElasticSearchService{T}"/> class.
  /// </summary>
  /// <param name="elasticClient"></param>
  /// <exception cref="System.ArgumentNullException">elasticClient</exception>
  /// <exception cref="ArgumentNullException">elasticClient</exception>
  public async Task<string> CreateDocumentAsync(T document)
  {
    var response = await _elasticClient.IndexDocumentAsync(document);
    return response.IsValid ? "Document created" : "Document not created";
  }

  /// <summary>
  /// Deletes the document.
  /// </summary>
  /// <param name="document"></param>
  /// <returns></returns>
  /// <exception cref="System.NotImplementedException"></exception>
  /// <exception cref="NotImplementedException"></exception>
  public async Task<string> DeleteDocumentAsync(int id)
  {
    var response = await _elasticClient.DeleteAsync(new DocumentPath<T>(id));
    return response.IsValid ? "Document deleted" : "Document not deleted";
  }

  /// <summary>
  /// Gets the document.
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  /// <exception cref="System.NotImplementedException"></exception>
  /// <exception cref="NotImplementedException"></exception>
  public async Task<T> GetDocumentAsync(int id)
  {
    var response = await _elasticClient.GetAsync(new DocumentPath<T>(id));
    return response.Source;
  }

  /// <summary>
  /// Gets the documents.
  /// </summary>
  /// <returns></returns>
  /// <exception cref="System.NotImplementedException"></exception>
  /// <exception cref="NotImplementedException"></exception>
  public async Task<IEnumerable<T>> GetDocumentsAsync()
  {
    var searchResponse = await _elasticClient
      .SearchAsync<T>(
        s =>
          s.MatchAll().Size(10000)
      );
    return searchResponse.Documents;
  }

  /// <summary>
  /// Updates the document.
  /// </summary>
  /// <param name="document"></param>
  /// <returns></returns>
  /// <exception cref="System.NotImplementedException"></exception>
  /// <exception cref="NotImplementedException"></exception>
  public async Task<string> UpdateDocumentAsync(T document)
  {
    var response = await _elasticClient
      .UpdateAsync
      (
        new DocumentPath<T>(document),
        u => u
          .Doc(document) // update the document
          .RetryOnConflict(3) // retry 3 times
      );
    return response.IsValid ? "Document updated" : "Document not updated";
  }
}