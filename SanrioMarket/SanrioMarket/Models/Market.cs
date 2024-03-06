namespace SanrioMarket.Models;

public class Market
{
    public Guid Id {get;}
    public string Name {get;}
    public string Description {get;}
    public DateTime StartDateTime {get;}
    public DateTime EndDateTime {get;}
    public DateTime LastModifiedDateTime {get;}
    public List<string> Traits {get;}
    
    public Market(Guid id,
                  string name,
                  string description,
                  DateTime startDateTime,
                  DateTime endDateTime,
                  DateTime lastModifiedDateTime,
                  List<string> traits)
    {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Traits = traits;
    }
}