namespace SanrioMarket.Contracts.Market;

public record UpsertMarketRequest(
    String Name,
    String Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Traits);