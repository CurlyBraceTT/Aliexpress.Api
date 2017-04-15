using Ali.Api.Parameters;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using System.Reflection;
using System;

namespace Ali.Api.Tests
{
    public class MethodsTests
    {
        private readonly IAliApiClient _client;

        public readonly string AppKey;
        public readonly string TrackingId;
        public readonly string AppSignature;

        public MethodsTests()
        {
            IConfigurationRoot config = null;

            // Work around for https://github.com/xunit/xunit/issues/1093
            // You can't debug your tests without 
            try
            {
                config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("settings.json")
                    .Build();
            }
            catch(Exception)
            {
                var location = typeof(MethodsTests).GetTypeInfo().Assembly.Location;
                var directory = Path.GetDirectoryName(location);

                config = new ConfigurationBuilder()
                    .SetBasePath(directory)
                    .AddJsonFile("settings.json")
                    .Build();
            }

            AppKey = config["Ali:AppKey"];

            if(AppKey == "YOUR_APP_KEY")
            {
                throw new Exception("Please fill your app information in settings.json file");
            }

            TrackingId = config["Ali:TrackingId"];
            AppSignature = config["Ali:AppSignature"];

            _client = new AliApiClient(new AliSettingsProvider
            {
                AppKey = AppKey
            });
        }

        [Fact]
        public async Task ProductsList()
        {
            var result = await _client.ListPromotionProduct(new ListPromotionProductParameters
            {
                Keywords = "Test"
            });

            Assert.True(result.TotalResults > 0);

            var urlsList = result.Products.Select(p => p.ProductUrl);
            var urls = string.Join(",", urlsList);

            var promotionItems = await _client.GetPromotionLinks(new GetPromotionLinksParameters
            {
                TrackingId = TrackingId,
                Urls = urls
            });

            Assert.True(promotionItems.TotalResults > 0);

            var testId = result.Products.First().ProductId;

            var item = await _client.GetPromotionProductDetail(new GetPromotionProductDetailParameters
            {
                ProductId = testId.ToString()
            });

            Assert.True(item.ProductId == testId);
        }

        [Fact]
        public async Task OrdersList()
        {
            var orders = await _client.GetCompletedOrders(new GetCompletedOrdersParameters
            {
                AppSignature = AppSignature,
                StartDate = DateTime.Now.AddMonths(-1),
                EndDate = DateTime.Now,
                LiveOrderStatus = "pay",
                PageNo = 1,
                PageSize = 15
            });

            if(orders.TotalResults > 0)
            {
                var statusOrders = await _client.GetOrderStatus(new GetOrderStatusParameters
                {
                    AppSignature = AppSignature,
                    OrderNumbers = string.Join(",", orders.Orders.Select(order => order.OrderNumber))
                });

                Assert.True(statusOrders.TotalResults > 0);

                var items = await _client.GetOrderStatus(new GetOrderStatusParameters
                {
                    AppSignature = AppSignature,
                    OrderNumbers = string.Join(",", orders.Orders.Select(order => order.OrderNumber))
                });

                Assert.True(items.TotalResults > 0);
            }

            // Assert if no exceptions
            Assert.True(true);
        }

        [Fact]
        public async Task HotProducts()
        {
            var result = await _client.ListHotProducts(new ListHotProductsParameters
            {

            });

            // Assert if no exceptions
            Assert.True(result.TotalResults > 0);
        }

        [Fact]
        public async Task SimilarAndPromotionsProducts()
        {
            var result = await _client.ListPromotionProduct(new ListPromotionProductParameters
            {
                Keywords = "Test"
            });
            Assert.True(result.TotalResults > 0);

            var testId = result.Products.First().ProductId;

            var similar = await _client.ListSimilarProducts(new ListSimilarProductsParameters
            {
                ProductId = testId.ToString()
            });
            Assert.True(similar.TotalResults > 0);

            var appPromotions = await _client.GetAppPromotionProduct(new GetAppPromotionProductParameters
            {
                ProductId = testId.ToString()
            });
            // Assert if no exceptions
            Assert.True(true);
        }
    }
}
