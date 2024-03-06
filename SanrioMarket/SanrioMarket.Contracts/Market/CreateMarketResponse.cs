namespace SanrioMarket.Contracts.Market;

public record CreateMarketResponse(
    Guid Id,
    String Name,
    String Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> Traits);