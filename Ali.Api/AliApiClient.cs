using Ali.Api.Exceptions;
using Ali.Api.Model;
using Ali.Api.Parameters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ali.Api
{
    /// <summary>
    /// Aliexpress Api client interface
    /// Docs are availible here after registration
    /// https://portals.aliexpress.com/help/help_center_API.html
    /// </summary>
    public interface IAliApiClient
    {
        /// <summary>
        /// Get the promotion products.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Promotion products result</returns>
        Task<ListPromotionProductResult> ListPromotionProduct(ListPromotionProductParameters parameters);

        /// <summary>
        /// Gets the promotion links.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Promotion links result</returns>
        Task<GetPromotionLinksResult> GetPromotionLinks(GetPromotionLinksParameters parameters);

        /// <summary>
        /// Gets the promotion product detail.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Product detail result</returns>
        Task<ProductResult> GetPromotionProductDetail(GetPromotionProductDetailParameters parameters);

        /// <summary>
        /// Gets list promotion banner.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Result</returns>
        Task<ListPromotionCreativeResult> ListPromotionCreative(ListPromotionCreativeParameters parameters);

        /// <summary>
        /// Gets the completed orders.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Completed Orders</returns>
        Task<GetCompletedOrdersResult> GetCompletedOrders(GetCompletedOrdersParameters parameters);

        /// <summary>
        /// Gets the order status.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Order Status result</returns>
        Task<GetOrderStatusResult> GetOrderStatus(GetOrderStatusParameters parameters);

        /// <summary>
        /// Gets the item by order numbers.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Order Items</returns>
        Task<GetItemByOrderNumbersResult> GetItemByOrderNumbers(GetItemByOrderNumbersParameters parameters);

        /// <summary>
        /// Gets list with the hot products.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Hot Products List</returns>
        Task<ListHotProductsResult> ListHotProducts(ListHotProductsParameters parameters);

        /// <summary>
        /// Gets list the similar products.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Similar Products List</returns>
        Task<ListSimilarProductsResult> ListSimilarProducts(ListSimilarProductsParameters parameters);

        /// <summary>
        /// Gets the application promotion product.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Result</returns>
        Task<GetAppPromotionProductResult> GetAppPromotionProduct(GetAppPromotionProductParameters parameters);

        /// <summary>
        /// Generic API call to the Aliexpress
        /// </summary>
        /// <typeparam name="T">Returned Type</typeparam>
        /// <typeparam name="TParam">The type of the parameter.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>T</returns>
        Task<T> ApiCall<T, TParam>(string method, TParam parameters);

        /// <summary>
        /// Generic raw call to the Aliexpress
        /// </summary>
        /// <typeparam name="T">Returned Type</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>T</returns>
        Task<T> RawApiCall<T>(string url);
    }

    public class AliSettingsProvider
    {
        // gw.api.alibaba.com
        public string DomainName { get; set; }
        // [appkey]
        public string AppKey { get; set; }
        // param2
        public string Protocol { get; set; }
        // 2
        public string Version { get; set; }
        // portals.open
        public string Namespace { get; set; }
        // Builder for parameters
        public ParametersBuilder ParametersBuilder { get; set; }

        public AliSettingsProvider()
        {
            DomainName = "gw.api.alibaba.com";
            Protocol = "param2";
            Version = 2.ToString();
            Namespace = "portals.open";
            ParametersBuilder = new ParametersBuilder();
        }

        public AliSettingsProvider(string appKey) : this()
        {
            AppKey = appKey;
        }
    }

    /// <summary>
    /// Aliexpress Api client
    /// Docs are availible here after registration
    /// https://portals.aliexpress.com/help/help_center_API.html
    /// </summary>
    /// <seealso cref="Ali.Api.IAliApiClient" />
    public class AliApiClient : IAliApiClient
    {
        private readonly AliSettingsProvider _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AliApiClient"/> class.
        /// </summary>
        /// <param name="settingsProvider">The settings provider.</param>
        public AliApiClient(AliSettingsProvider settingsProvider)
        {
            _settings = settingsProvider;
        }

        /// <summary>
        /// Get the promotion products.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// Promotion products result
        /// </returns>
        public async Task<ListPromotionProductResult> ListPromotionProduct(ListPromotionProductParameters parameters)
        {
            return await ApiCall<ListPromotionProductResult, ListPromotionProductParameters>(AliApiMethods.ListPromotionProduct, parameters);
        }

        /// <summary>
        /// Gets the promotion links.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// Promotion links result
        /// </returns>
        public async Task<GetPromotionLinksResult> GetPromotionLinks(GetPromotionLinksParameters parameters)
        {
            return await ApiCall<GetPromotionLinksResult, GetPromotionLinksParameters>(AliApiMethods.GetPromotionLinks, parameters);
        }

        /// <summary>
        /// Gets the promotion product detail.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// Product detail result
        /// </returns>
        public async Task<ProductResult> GetPromotionProductDetail(GetPromotionProductDetailParameters parameters)
        {
            return await ApiCall<ProductResult, GetPromotionProductDetailParameters>(AliApiMethods.GetPromotionProductDetail, parameters);
        }

        /// <summary>
        /// Gets list promotion banner.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// Result
        /// </returns>
        public async Task<ListPromotionCreativeResult> ListPromotionCreative(ListPromotionCreativeParameters parameters)
        {
            return await ApiCall<ListPromotionCreativeResult, ListPromotionCreativeParameters>(AliApiMethods.ListPromotionCreative, parameters);
        }

        /// <summary>
        /// Gets the completed orders.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// Completed Orders
        /// </returns>
        public async Task<GetCompletedOrdersResult> GetCompletedOrders(GetCompletedOrdersParameters parameters)
        {
            return await ApiCall<GetCompletedOrdersResult, GetCompletedOrdersParameters>(AliApiMethods.GetCompletedOrders, parameters);
        }

        /// <summary>
        /// Gets the order status.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// Order Status result
        /// </returns>
        public async Task<GetOrderStatusResult> GetOrderStatus(GetOrderStatusParameters parameters)
        {
            return await ApiCall<GetOrderStatusResult, GetOrderStatusParameters>(AliApiMethods.GetOrderStatus, parameters);
        }

        /// <summary>
        /// Gets the item by order numbers.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// Order Items
        /// </returns>
        public async Task<GetItemByOrderNumbersResult> GetItemByOrderNumbers(GetItemByOrderNumbersParameters parameters)
        {
            return await ApiCall<GetItemByOrderNumbersResult, GetItemByOrderNumbersParameters>(AliApiMethods.GetItemByOrderNumbers, parameters);
        }

        /// <summary>
        /// Gets list with the hot products.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// Hot Products List
        /// </returns>
        public async Task<ListHotProductsResult> ListHotProducts(ListHotProductsParameters parameters)
        {
            return await ApiCall<ListHotProductsResult, ListHotProductsParameters>(AliApiMethods.ListHotProducts, parameters);
        }

        /// <summary>
        /// Gets list the similar products.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// Similar Products List
        /// </returns>
        public async Task<ListSimilarProductsResult> ListSimilarProducts(ListSimilarProductsParameters parameters)
        {
            return await ApiCall<ListSimilarProductsResult, ListSimilarProductsParameters>(AliApiMethods.ListSimilarProducts, parameters);
        }

        /// <summary>
        /// Gets the application promotion product.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// Result
        /// </returns>
        public async Task<GetAppPromotionProductResult> GetAppPromotionProduct(GetAppPromotionProductParameters parameters)
        {
            return await ApiCall<GetAppPromotionProductResult, GetAppPromotionProductParameters>(AliApiMethods.GetAppPromotionProduct, parameters);
        }

        /// <summary>
        /// Generic API call to the Aliexpress
        /// </summary>
        /// <typeparam name="T">Returned Type</typeparam>
        /// <typeparam name="TParam">The type of the parameter.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// T
        /// </returns>
        public async Task<T> ApiCall<T, TParam>(string method, TParam parameters)
        {
            var url = BuildUrl(method, parameters);
            return await RawApiCall<T>(url);
        }

        /// <summary>
        /// Generic raw call to the Aliexpress
        /// </summary>
        /// <typeparam name="T">Returned Type</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// T
        /// </returns>
        /// <exception cref="AliApiException"></exception>
        public async Task<T> RawApiCall<T>(string url)
        {
            using (var client = CreateClient())
            {
                var response = await client.GetStringAsync(url);
                JObject parsed = JObject.Parse(response);

                var callCode = parsed["errorCode"].Value<int>();

                if(callCode != ErrorCodes.SucceedCode)
                {
                    var message = ErrorCodes.GetMessage(callCode);
                    throw new AliApiException(callCode, message);
                }

                var result = JsonConvert.DeserializeObject<T>(parsed["result"].ToString(),
                    new JsonSerializerSettings
                    {
                        /*
                         * Because Aliexpress Api logic is very weird - 
                         * it could return "-" for totalResults field, 
                         * Which is Integer by documentation and common sense
                        */
                        Error = HandleDeserializationError
                    });

                return result;
            }
        }

        /// <summary>
        /// Handles the json deserialization error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="errorArgs">The <see cref="ErrorEventArgs"/> instance containing the event data.</param>
        protected void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        /// <summary>
        /// Creates the Http client for internal usage.
        /// Called on every request
        /// </summary>
        /// <returns>Http Client</returns>
        protected HttpClient CreateClient()
        {
            var client = new HttpClient();
            return client;
        }

        /// <summary>
        /// Builds the URL from the parameters
        /// </summary>
        /// <typeparam name="TParam">The type of the parameter.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        protected string BuildUrl<TParam>(string method, TParam parameters)
        {
            return string.Format("https://{0}/openapi/{1}/{2}/portals.open/{3}/{4}?{5}", _settings.DomainName, _settings.Protocol, 
                _settings.Version, method, _settings.AppKey, _settings.ParametersBuilder.Build(parameters));
        }
    }
}
