using ErrorOr;

namespace SanrioMarket.ServiceErrors;

public static class Errors
{
    public static class Market
    {
        public static Error NotFound => Error.NotFound(
            code: "Market.NotFound",
            description: "Market not found"
        );
    }
}