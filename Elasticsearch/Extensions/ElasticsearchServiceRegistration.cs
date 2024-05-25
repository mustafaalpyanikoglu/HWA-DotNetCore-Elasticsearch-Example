using Nest;
using RedisElasticDemo.Constants;
using RedisElasticDemo.Elasticsearch.Models;

namespace RedisElasticDemo.Elasticsearch.Services;

/// <summary>
/// Extension method to register Elasticsearch services
/// </summary>
/// <param name="services">The service collection</param>
/// <param name="configuration">The configuration</param>
/// <returns>The service collection</returns>
/// <exception cref="ArgumentNullException">Thrown when the Elasticsearch configuration is missing</exception>
public static class ElasticsearchServiceRegistration
{
    public static IServiceCollection AddElasticSearchServices(this IServiceCollection services, IConfiguration configuration)
    {
        ElasticSearchConfig? elasticSearch = configuration.GetSection("ElasticSearchConfig").Get<ElasticSearchConfig>();

        if (elasticSearch == null)
            throw new ArgumentNullException(nameof(elasticSearch), AppMessages.ElasticSearchConfigMissing);

        var settings = new ConnectionSettings(new Uri(elasticSearch.ConnectionString))
            .DefaultIndex(elasticSearch.IndexName)
            .BasicAuthentication(elasticSearch.UserName, elasticSearch.Password);

        if (elasticSearch.DisableCertificateValidation)
            settings.ServerCertificateValidationCallback((sender, certificate, chain, sslPolicyErrors) => true);

        var client = new ElasticClient(settings);

        services.AddSingleton(client);
        services.AddTransient(typeof(IElasticSearchService<>), typeof(ElasticSearchService<>));

        return services;
    }
}
