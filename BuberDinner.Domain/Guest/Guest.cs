using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;
public sealed class Guest : AggregateRoot<GuestId>
{
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();

    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }

    public AverageRating AverageRating { get; set; }
    public UserId UserId { get; set; }

    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public DateTime CreatedDateTimeTime { get; }
    public DateTime LastUpdatedDateTime { get; }

    private Guest(
        GuestId id,
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
        UserId = userId;
        CreatedDateTimeTime = createdDateTime;
        LastUpdatedDateTime = lastUpdatedDateTime;
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new Guest(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
