
namespace RedisElasticDemo.Models;

public class MyDocument
{
    /// <summary>
    /// The Id property is used to uniquely identify the document.
    /// </summary>
    public int Id { get; set; } = new Random().Next();
    /// <summary>
    /// The Name property is used to store the name of the document.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The Description property is used to store the description of the document.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// The Author property is used to store the author of the document.
    /// </summary>
    public string Author { get; set; }
}