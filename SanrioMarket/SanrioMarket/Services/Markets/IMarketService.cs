using ErrorOr;
using SanrioMarket.Contracts.Market;
using SanrioMarket.Models;

namespace SanrioMarket.Services.Markets;

public interface IMarketService{
    ErrorOr<Created> CreateMarket(Market market);
    ErrorOr<Deleted> DeleteMarket(Guid id);
    ErrorOr<Market> GetMarket(Guid id);
    ErrorOr<UpsertedMarket> UpsertMarket(Market market);
}