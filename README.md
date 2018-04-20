# Aliexpress.Api

Aliexpress Api high level client written on C#

## About
* Build on Asp.net core 2.0
* Wraps all results into strong-typed models
* Parses API exceptions
* Tests included
* Service Collection extension for easy integration

## Getting started

To add client into dependency injection services:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAliClient(settings =>
    {
        settings.AppKey = "YOURAPPKEY";
    });
}
```

Then client will be injected, for example simple MVC Controller:

```csharp
[Route("api/[controller]")]
public class AliController : Controller
{
    private readonly IAliexpressApiClient _aliClient;

    public AliController(IAliexpressApiClient aliClient)
    {
        _logger = logger;
        _aliClient = aliClient;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string keywords)
    {
        var items = await _aliClient.ListPromotionProduct(new ListPromotionProductParameters
        {
            Keywords = keywords
        });

        return Json(items);
    }
}
```


Original Aliexpress API documentation is [Here](https://portals.aliexpress.com/help/help_center_API.html)

*Note: You need to register at [https://portals.aliexpress.com](https://portals.aliexpress.com)*

## Tests
To setup tests - please edit settings.json file and paste your App key, tracking and signature ids there.

## How to create actual Promotion urls using raw product url?
Here is the harsh example of what you need to do.

```csharp
// Get some products
var items = await _aliClient.ListPromotionProduct(new ListPromotionProductParameters
{
    Keywords = keywords
});

// Create comma-separated list of urls
var urlsList = items.Products.Select(p => p.ProductUrl);
var urls = string.Join(",", urlsList);

// Get promotions urls by list of urls
var processed = await _aliClient.GetPromotionLinks(new GetPromotionLinksParameters
{
    TrackingId = "YOURTRACKINGID",
    Urls = urls
});

// Get promotion url and paste it in your original results
foreach(var i in items.Products)
{
    var trueUrl = processed.PromotionUrls.SingleOrDefault(u => u.Url == i.ProductUrl);

    if(trueUrl != null)
    {
        i.ProductUrl = trueUrl.PromotionUrl;
    }
}
```
