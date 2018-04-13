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
    public interface IAliApiClient
    {
        Task<ListPromotionProductResult> ListPromotionProduct(ListPromotionProductParameters parameters);
        Task<GetPromotionLinksResult> GetPromotionLinks(GetPromotionLinksParameters parameters);
        Task<ProductResult> GetPromotionProductDetail(GetPromotionProductDetailParameters parameters);
        Task<ListPromotionCreativeResult> ListPromotionCreative(ListPromotionCreativeParameters parameters);
        Task<GetCompletedOrdersResult> GetCompletedOrders(GetCompletedOrdersParameters parameters);
        Task<GetOrderStatusResult> GetOrderStatus(GetOrderStatusParameters parameters);
        Task<GetItemByOrderNumbersResult> GetItemByOrderNumbers(GetItemByOrderNumbersParameters parameters);
        Task<ListHotProductsResult> ListHotProducts(ListHotProductsParameters parameters);
        Task<ListSimilarProductsResult> ListSimilarProducts(ListSimilarProductsParameters parameters);
        Task<GetAppPromotionProductResult> GetAppPromotionProduct(GetAppPromotionProductParameters parameters);
        
        Task<T> ApiCall<T, TParam>(string method, TParam parameters);
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

    public class AliApiClient : IAliApiClient
    {
        private readonly AliSettingsProvider _settings;

        public AliApiClient(AliSettingsProvider settingsProvider)
        {
            _settings = settingsProvider;
        }

        public async Task<ListPromotionProductResult> ListPromotionProduct(ListPromotionProductParameters parameters)
        {
            return await ApiCall<ListPromotionProductResult, ListPromotionProductParameters>(AliApiMethods.ListPromotionProduct, parameters);
        }

        public async Task<GetPromotionLinksResult> GetPromotionLinks(GetPromotionLinksParameters parameters)
        {
            return await ApiCall<GetPromotionLinksResult, GetPromotionLinksParameters>(AliApiMethods.GetPromotionLinks, parameters);
        }

        public async Task<ProductResult> GetPromotionProductDetail(GetPromotionProductDetailParameters parameters)
        {
            return await ApiCall<ProductResult, GetPromotionProductDetailParameters>(AliApiMethods.GetPromotionProductDetail, parameters);
        }

        public async Task<ListPromotionCreativeResult> ListPromotionCreative(ListPromotionCreativeParameters parameters)
        {
            return await ApiCall<ListPromotionCreativeResult, ListPromotionCreativeParameters>(AliApiMethods.ListPromotionCreative, parameters);
        }

        public async Task<GetCompletedOrdersResult> GetCompletedOrders(GetCompletedOrdersParameters parameters)
        {
            return await ApiCall<GetCompletedOrdersResult, GetCompletedOrdersParameters>(AliApiMethods.GetCompletedOrders, parameters);
        }

        public async Task<GetOrderStatusResult> GetOrderStatus(GetOrderStatusParameters parameters)
        {
            return await ApiCall<GetOrderStatusResult, GetOrderStatusParameters>(AliApiMethods.GetOrderStatus, parameters);
        }

        public async Task<GetItemByOrderNumbersResult> GetItemByOrderNumbers(GetItemByOrderNumbersParameters parameters)
        {
            return await ApiCall<GetItemByOrderNumbersResult, GetItemByOrderNumbersParameters>(AliApiMethods.GetItemByOrderNumbers, parameters);
        }

        public async Task<ListHotProductsResult> ListHotProducts(ListHotProductsParameters parameters)
        {
            return await ApiCall<ListHotProductsResult, ListHotProductsParameters>(AliApiMethods.ListHotProducts, parameters);
        }

        public async Task<ListSimilarProductsResult> ListSimilarProducts(ListSimilarProductsParameters parameters)
        {
            return await ApiCall<ListSimilarProductsResult, ListSimilarProductsParameters>(AliApiMethods.ListSimilarProducts, parameters);
        }

        public async Task<GetAppPromotionProductResult> GetAppPromotionProduct(GetAppPromotionProductParameters parameters)
        {
            return await ApiCall<GetAppPromotionProductResult, GetAppPromotionProductParameters>(AliApiMethods.GetAppPromotionProduct, parameters);
        }

        public async Task<T> ApiCall<T, TParam>(string method, TParam parameters)
        {
            var url = BuildUrl(method, parameters);
            return await RawApiCall<T>(url);
        }

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

        protected void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

        protected HttpClient CreateClient()
        {
            var client = new HttpClient();
            return client;
        }

        protected string BuildUrl<TParam>(string method, TParam parameters)
        {
            return string.Format("https://{0}/openapi/{1}/{2}/portals.open/{3}/{4}?{5}", _settings.DomainName, _settings.Protocol, 
                _settings.Version, method, _settings.AppKey, _settings.ParametersBuilder.Build(parameters));
        }
    }
}
