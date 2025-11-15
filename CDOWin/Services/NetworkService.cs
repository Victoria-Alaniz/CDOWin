using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CDOWin.Services {
    public class NetworkService {
        // Singleton instance
        private static readonly Lazy<NetworkService> _instance = new(() => new NetworkService());
        public static NetworkService Instance => _instance.Value;

        // Properties
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        // Private constructor
        private NetworkService() {
            _httpClient = new HttpClient();
            _jsonOptions = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
            };
        }

        // Initialize the service with API credentials
        public void Initialize(string baseAddress, string apiKey) {
            if (string.IsNullOrWhiteSpace(baseAddress))
                throw new ArgumentException("Base address must be provided.");
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("API Key must be provided.");

            Debug.WriteLine($"Base Address: {baseAddress}, API-Key: {apiKey}");

            // Initialize HttpClient
            _httpClient.BaseAddress = new Uri(baseAddress);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }

        public static async Task<bool> IsAPIKeyValidAsync(string address, string apiKey) {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            client.BaseAddress = new Uri(address);
            var response = await client.GetAsync("api/");
            return response.IsSuccessStatusCode;
        }

        public async Task<T?> GetAsync<T>(string endpoint) {
            var response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode) {
                return default;
            }

            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(stream, _jsonOptions);
        }
    }
}
