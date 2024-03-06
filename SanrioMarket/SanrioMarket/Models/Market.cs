using ErrorOr;
using SanrioMarket.Contracts.Market;
using SanrioMarket.ServiceErrors;

namespace SanrioMarket.Models;

public class Market
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;
    public const int MinDescriptionLength = 10;
    public const int MaxDescriptionLength = 150;
    public Guid Id {get;}
    public string Name {get;}
    public string Description {get;}
    public DateTime StartDateTime {get;}
    public DateTime EndDateTime {get;}
    public DateTime LastModifiedDateTime {get;}
    public List<string> Traits {get;}
    
    private Market(Guid id,
                  string name,
                  string description,
                  DateTime startDateTime,
                  DateTime endDateTime,
                  DateTime lastModifiedDateTime,
                  List<string> traits)
    {
        //enforce invariants
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Traits = traits;
    }

    public static ErrorOr<Market> Create(string name,
                                         string description,
                                         DateTime startDateTime,
                                         DateTime endDateTime,
                                         List<string> traits,
                                         Guid? id = null
    )
    {
        List<Error> errors = new();
        if(name.Length is < MinNameLength or > MaxNameLength){
            errors.Add(Errors.Market.InvalidName);
        }
        if(description.Length is < MinDescriptionLength or > MaxDescriptionLength){
            errors.Add(Errors.Market.InvalidDescription);
        }

        if(errors.Count > 0)
        {
            return errors;
        }

        return new Market(id ?? Guid.NewGuid(),
                          name,
                          description,
                          startDateTime,
                          endDateTime,
                          DateTime.UtcNow,
                          traits);
    }

    public static ErrorOr<Market> From(CreateMarketRequest request)
    {
        return Create(request.Name,
                      request.Description,
                      request.StartDateTime,
                      request.EndDateTime,
                      request.Traits
        );
    }

    public static ErrorOr<Market> From(Guid id, UpsertMarketRequest request)
    {
        return Create(request.Name,
                      request.Description,
                      request.StartDateTime,
                      request.EndDateTime,
                      request.Traits,
                      id
        );
    }
}