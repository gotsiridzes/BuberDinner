# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id":"",
    "name":"menu name",
    "description": "",
    "averateRating": 4.5,
    "sections": [
        {
            "id":"",
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                {
                    "id": "",
                    "name": "",
                    "description": "",
                    "price": 0.00
                }
            ]
        }
    ],
    "createdDateTime":"",
    "updatedDateTime":"",
    "hostId":"",
    "dinnerIds": ["",""],
    "menuReviewIds":["",""]
}
```