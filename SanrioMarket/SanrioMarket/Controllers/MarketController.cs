using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using SanrioMarket.Contracts.Market;
using SanrioMarket.Models;
using SanrioMarket.Services.Markets;

namespace SanrioMarket.Controllers;

[ApiController]
[Route("[controller]")]
public class MarketController : ControllerBase
{
    private readonly IMarketService _marketService;

    public MarketController(IMarketService marketService){
        _marketService = marketService;
    }
    [HttpPost("")]
    public IActionResult CreateMarket(CreateMarketRequest request){
        var market = new Market(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Traits
        );

        _marketService.CreateMarket(market);

        var response = new CreateMarketResponse(
            market.Id,
            market.Name,
            market.Description,
            market.StartDateTime,
            market.EndDateTime,
            market.LastModifiedDateTime,
            market.Traits
        );
        return CreatedAtAction(
            actionName: nameof(GetMarket),
            routeValues: new {id = market.Id},
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetMarket(Guid id){
        Market market = _marketService.GetMarket(id);

        var response = new CreateMarketResponse(
            market.Id,
            market.Name,
            market.Description,
            market.StartDateTime,
            market.EndDateTime,
            market.LastModifiedDateTime,
            market.Traits
        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertMarket(Guid id, UpsertMarketRequest request){
        var market = new Market(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Traits
        );

        _marketService.UpsertMarket(market);
        //TODO: return 201 if new market is created
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteMarket(Guid id){
        _marketService.DeleteMarket(id);
        return NoContent();
    }
}