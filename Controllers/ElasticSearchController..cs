using Microsoft.AspNetCore.Mvc;
using RedisElasticDemo.Models;
using RedisElasticDemo.Elasticsearch.Services;
using Swashbuckle.AspNetCore.Annotations;
using static RedisElasticDemo.Constants.ResponseDescriptions;

namespace RedisElasticDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ElasticSearchController
    (IElasticSearchService<MyDocument> elasticSearchService) : ControllerBase
{
    private readonly IElasticSearchService<MyDocument> _elasticSearchService = elasticSearchService;

    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [SwaggerOperation(CREATE_ELASTICSEARCH_DOCUMENT)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MyDocument document)
    {
        var result = await _elasticSearchService.CreateDocumentAsync(document);
        return Ok(result);
    }

    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [SwaggerOperation(UPDATE_ELASTICSEARCH_DOCUMENT)]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] MyDocument document)
    {
        var result = await _elasticSearchService.UpdateDocumentAsync(document);
        return Ok(result);
    }


    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [SwaggerOperation(GET_ELASTICSEARCH_DOCUMENT)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _elasticSearchService.DeleteDocumentAsync(id);
        return Ok(result);
    }


    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [SwaggerOperation(GET_ELASTICSEARCH_DOCUMENTS)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _elasticSearchService.GetDocumentAsync(id);
        return Ok(result);
    }


    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [SwaggerOperation(GET_ELASTICSEARCH_DOCUMENTS)]
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var result = await _elasticSearchService.GetDocumentsAsync();
        return Ok(result);
    }

}
