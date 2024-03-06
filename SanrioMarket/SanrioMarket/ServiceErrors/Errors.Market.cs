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

        public static Error InvalidName => Error.Validation(
            code: "Market.InvalidName",
            description: $"Market name must be at least {Models.Market.MinNameLength}" +
                $" characters long and at most {Models.Market.MaxNameLength} characters long."
        );

        public static Error InvalidDescription => Error.Validation(
            code: "Market.InvalidDescription",
            description: $"Market description must be at least {Models.Market.MinDescriptionLength}" +
                $" characters long and at most {Models.Market.MaxDescriptionLength} characters long."
        );
    }
}