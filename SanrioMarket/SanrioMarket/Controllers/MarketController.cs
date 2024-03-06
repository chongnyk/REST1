using System.Net.Http.Headers;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SanrioMarket.Contracts.Market;
using SanrioMarket.Models;
using SanrioMarket.ServiceErrors;
using SanrioMarket.Services.Markets;

namespace SanrioMarket.Controllers;

public class MarketController : ApiController
{
    private readonly IMarketService _marketService;

    public MarketController(IMarketService marketService){
        _marketService = marketService;
    }
    [HttpPost("")]
    public IActionResult CreateMarket(CreateMarketRequest request)
    {
        var market = new Market(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Traits
        );

        ErrorOr<Created> createMarketResult = _marketService.CreateMarket(market);

        return createMarketResult.Match(
            created => CreatedAtGetMarket(market),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetMarket(Guid id)
    {
        ErrorOr<Market> getMarketResult = _marketService.GetMarket(id);

        return getMarketResult.Match(
            market => Ok(MapMarketResponse(market)),
            errors => Problem(errors)
        );
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
        
        ErrorOr<UpsertedMarket> upserteMarketResult = _marketService.UpsertMarket(market);
        //TODO: return 201 if new market is created
        return upserteMarketResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetMarket(market) : NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteMarket(Guid id){
        ErrorOr<Deleted> deleteMarketResult = _marketService.DeleteMarket(id);

        return deleteMarketResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private static CreateMarketResponse MapMarketResponse(Market market)
    {
        return new CreateMarketResponse(
                    market.Id,
                    market.Name,
                    market.Description,
                    market.StartDateTime,
                    market.EndDateTime,
                    market.LastModifiedDateTime,
                    market.Traits
                );
    }

    private IActionResult CreatedAtGetMarket(Market market)
    {
        return CreatedAtAction(
            actionName: nameof(GetMarket),
            routeValues: new { id = market.Id },
            value: MapMarketResponse(market));
    }
}