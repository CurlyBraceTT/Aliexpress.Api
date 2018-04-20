using Aliexpress.Api.Parameters;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using System.Reflection;
using System;

namespace Aliexpress.Api.Tests
{
    /// <summary>
    /// Tests for the Aliexpress Api
    /// </summary>
    public class MethodsTests
    {
        public const string CONFIG_FILE_NAME = "settings.json";
        private readonly IAliexpressApiClient _client;

        public readonly string AppKey;
        public readonly string TrackingId;
        public readonly string AppSignature;

        public MethodsTests()
        {
            IConfigurationRoot config = null;

            // Work around for https://github.com/xunit/xunit/issues/1093
            try
            {
                config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    // Order is essential here - we are overriding local json config with user secrets
                    .AddJsonFile(CONFIG_FILE_NAME)
                    .AddUserSecrets<MethodsTests>()
                    .Build();
            }
            catch(Exception)
            {
                var location = typeof(MethodsTests).GetTypeInfo().Assembly.Location;
                var directory = Path.GetDirectoryName(location);

                config = new ConfigurationBuilder()
                    .SetBasePath(directory)
                    .AddJsonFile(CONFIG_FILE_NAME)
                    .Build();
            }

            AppKey = config["Ali:AppKey"];

            if(AppKey == "YOUR_APP_KEY")
            {
                throw new Exception("Please fill your app information in settings.json file");
            }

            TrackingId = config["Ali:TrackingId"];
            AppSignature = config["Ali:AppSignature"];

            _client = new AliexpressApiClient(new AliexpressSettingsProvider
            {
                AppKey = AppKey
            });
        }

        /// <summary>
        /// Tests list of the product
        /// </summary>
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

        /// <summary>
        /// Tests the orders the list.
        /// </summary>
        [Fact]
        public async Task Orders()
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

                var status = await _client.GetOrderStatus(new GetOrderStatusParameters
                {
                    AppSignature = AppSignature,
                    OrderNumbers = string.Join(",", orders.Orders.Select(order => order.OrderNumber))
                });
                Assert.True(status.TotalResults > 0);

                var items = await _client.GetItemByOrderNumbers(new GetItemByOrderNumbersParameters 
                {
                    AppSignature = AppSignature,
                    OrderNumbers = string.Join(",", orders.Orders.Select(order => order.OrderNumber))
                });
                Assert.True(items.TotalResults > 0);
            }

            // Assert if no exceptions
            Assert.True(true);
        }

        /// <summary>
        /// Tests for the Hot products.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task HotProducts()
        {
            var result = await _client.ListHotProducts(new ListHotProductsParameters
            {

            });

            // Assert if no exceptions
            Assert.True(result.TotalResults > 0);
        }

        /// <summary>
        /// Tests promotions products.
        /// </summary>
        [Fact]
        public async Task PromotionsProducts()
        {
            var result = await _client.ListPromotionProduct(new ListPromotionProductParameters
            {
                Keywords = "Test"
            });
            Assert.True(result.TotalResults > 0);

            var testId = 32851732627;// result.Products.First().ProductId;

            /*
            var similar = await _client.ListSimilarProducts(new ListSimilarProductsParameters
            {
                ProductId = testId.ToString()
            });
            Assert.True(similar.TotalResults > 0);
            */

            var appPromotions = await _client.GetAppPromotionProduct(new GetAppPromotionProductParameters
            {
                ProductId = testId.ToString()
            });
            // Assert if no exceptions
            Assert.True(true);
        }

        /// <summary>
        /// Tests promotions creative products.
        /// </summary>
        [Fact]
        public async Task ListPromotionCreative()
        {
            var result = await _client.ListPromotionCreative(new ListPromotionCreativeParameters
            {
                AppSignature = AppSignature,
                Category = "all",
                Language = "en"
            });
            Assert.True(result.TotalResults > 0);
        }
    }
}
