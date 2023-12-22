using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResponseCaching.API.Application.Messages.Commands;
using ResponseCaching.API.Application.Messages.Queries;
using ResponseCaching.API.Data.Entities;

namespace ResponseCaching.API.Data.Repositories;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET api/products/decorator-pattern 
    /// <summary>
    /// Obtém todas os produtos realizando cache com Decorator Pattern
    /// </summary>   
    /// <response code="200">Sucesso</response>               
    /// <response code="204">Nenhum registro localizado</response>         
    [HttpGet("decorator-pattern")]
    [ProducesResponseType(typeof(List<ProductModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllProductsDecoratorPattern()
    {
        var result = await _mediator.Send(new FindAllProductsDecoratorPatternQuery());

        return result == null ? NoContent() : Ok(result);
    }

    // GET api/products/pipeline-behaviour
    /// <summary>
    /// Obtém todas os produtos realizando cache com Pipeline Behaviour
    /// </summary>   
    /// <response code="200">Sucesso</response>               
    /// <response code="204">Nenhum registro localizado</response>         
    [HttpGet("pipeline-behaviour")]
    [ProducesResponseType(typeof(List<ProductModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllProductsPipelineBehaviour()
    {
        var result = await _mediator.Send(new FindAllProductsPipelineBehaviourQuery());

        return result == null ? NoContent() : Ok(result);
    }

    // GET api/products/response-caching
    /// <summary>
    /// Obtém todas os produtos realizando cache com Response Caching
    /// </summary>   
    /// <response code="200">Sucesso</response>               
    /// <response code="204">Nenhum registro localizado</response>         
    [HttpGet("response-caching")]
    [ResponseCache(CacheProfileName = "Client")]
    [ProducesResponseType(typeof(List<ProductModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllProductsResponseCaching()
    {
        var result = await _mediator.Send(new FindAllProductsResponseCachingQuery());

        return result == null ? NoContent() : Ok(result);
    }

    // POST api/products/
    /// <summary>
    /// Grava o produto
    /// </summary>   
    /// <remarks>
    /// Exemplo request:
    ///
    ///     POST / Produto
    ///     {
    ///         "title": "Sandalia",
    ///         "description": "Sandália Preta Couro Salto Fino",
    ///         "price": 249.50,
    ///         "quantity": 100       
    ///     }
    /// </remarks>        
    /// <returns>Retorna objeto criado da classe Produto</returns>                
    /// <response code="201">O produto foi incluído corretamente</response>                
    /// <response code="400">Falha na requisição</response>         
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ActionName("NewProduct")]
    public async Task<IActionResult> PostAsync([FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);

        return result.IsValid() ? CreatedAtAction("NewProduct", new { id = result.Response }, command) : BadRequest(result.Errors);
    }

}
