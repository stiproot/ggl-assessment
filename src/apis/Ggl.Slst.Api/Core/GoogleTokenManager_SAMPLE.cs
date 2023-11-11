public class GoogleTokenManager
{
    private readonly HttpClient _httpClient;
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string _redirectUri;
    private string _accessToken;
    private string _refreshToken;
    private DateTime _tokenExpiration;

    public GoogleTokenManager(string clientId, string clientSecret, string redirectUri)
    {
        _httpClient = new HttpClient();
        _clientId = clientId;
        _clientSecret = clientSecret;
        _redirectUri = redirectUri;
    }

    public async Task<string> GetAccessToken()
    {
        if (string.IsNullOrEmpty(_accessToken) || DateTime.UtcNow >= _tokenExpiration)
        {
            await RefreshToken();
        }

        return _accessToken;
    }

    private async Task RefreshToken()
    {
        // Use the refresh token to obtain a new access token
        // Make a request to the token endpoint of the OAuth 2.0 server (Google)
        // Include the refresh token, client ID, client secret, and any other required parameters
        // Update the stored access token and expiration time

        // Example (replace with your actual token endpoint and parameters):
        var tokenEndpoint = "https://oauth2.googleapis.com/token";
        var parameters = new Dictionary<string, string>
        {
            { "grant_type" , "refresh_token" },
            { "refresh_token",  _refreshToken },
            { "client_id", _clientId },
            { "client_secret", _clientSecret },
            { "redirect_uri",  _redirectUri }
        };

        var response = await _httpClient.PostAsync(tokenEndpoint, new FormUrlEncodedContent(parameters));

        if (response.IsSuccessStatusCode)
        {
            var tokenResponse = await response.Content.ReadAsAsync<TokenResponse>();
            _accessToken = tokenResponse.access_token;
            _tokenExpiration = DateTime.UtcNow.AddSeconds(tokenResponse.expires_in);
            _refreshToken = tokenResponse.refresh_token;
        }
        else
        {
            // Handle token refresh failure
            throw new Exception($"Token refresh failed: {response.ReasonPhrase}");
        }
    }

    // Class to represent the token response (customize based on your actual response structure)
    private class TokenResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public int expires_in { get; set; }
    }
}
