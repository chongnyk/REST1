namespace SanrioMarket.Contracts.Market;

public record CreateMarketRequest(
    String Name,
    String Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Traits);

