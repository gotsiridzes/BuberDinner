using System.Security.AccessControl;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();

    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    
    public UserId UserId { get; }

    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public DateTime CreatedDateTimeTime { get; }
    public DateTime LastUpdatedDateTime { get; }

    private Host(
        HostId id,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime lastUpdatedDateTime) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        CreatedDateTimeTime = createdDateTime;
        LastUpdatedDateTime = lastUpdatedDateTime;
        UserId = userId;
    }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new Host(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
