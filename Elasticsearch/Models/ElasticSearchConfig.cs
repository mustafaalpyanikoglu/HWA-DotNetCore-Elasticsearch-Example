namespace RedisElasticDemo.Elasticsearch.Models;

/// <summary>
/// The Elasticsearch configuration
/// </summary>
/// <param name="ConnectionString">The connection string</param>
/// <param name="UserName">The username</param>
/// <param name="Password">The password</param>
/// <param name="IndexName">The index name</param>
/// <param name="DisableCertificateValidation">The flag to disable certificate validation</param>
/// <returns>The Elasticsearch configuration</returns>
/// <exception cref="ArgumentNullException">Thrown when the Elasticsearch configuration is missing</exception>
public class ElasticSearchConfig
{
  /// <summary>
  /// The connection string
  /// </summary>
  public string ConnectionString { get; set; }
  /// <summary>
  /// The username
  /// </summary>
  public string UserName { get; set; }
  /// <summary>
  /// The password
  /// </summary>
  public string Password { get; set; }
  /// <summary>
  /// The index name
  /// </summary>
  public bool DisableCertificateValidation { get; set; }
  /// <summary>
  /// The flag to disable certificate validation
  /// </summary>
  public string IndexName { get; set; }

  /// <summary>
  /// The default constructor
  /// </summary>
  /// <returns>The Elasticsearch configuration</returns>
  public ElasticSearchConfig()
  {
    ConnectionString = string.Empty;
    UserName = string.Empty;
    Password = string.Empty;
    IndexName = string.Empty;
    DisableCertificateValidation = true;
  }

  /// <summary>
  /// The parameterized constructor
  /// </summary>
  /// <param name="connectionString">The connection string</param>
  /// <param name="userName">The username</param>
  /// <param name="password">The password</param>
  /// <param name="indexName">The index name</param>
  /// <param name="disableCertificateValidation">The flag to disable certificate validation</param>
  /// <returns>The Elasticsearch configuration</returns>
  public ElasticSearchConfig(
    string connectionString, string userName,
    string password, string indexName,
    bool disableCertificateValidation)
  {
    ConnectionString = connectionString;
    UserName = userName;
    Password = password;
    IndexName = indexName;
    DisableCertificateValidation = disableCertificateValidation;
  }
}
