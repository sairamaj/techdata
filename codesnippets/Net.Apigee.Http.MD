
# Using Http for Apigee
```csharp
  internal class ApigeeRepository : IApigeeRepository
    {
        public async Task<IEnumerable<ApiProxy>> GetApiProxies(Environment env)
        {
            var tokenResponse = await GetAuthToken<ApigeeAccessToken>(new ApigeeUrlFormatter(env.Organization).Login, env);
            Console.WriteLine(tokenResponse.AccessToken);
            var proxyNames = await GetRequest<string[]>(new ApigeeUrlFormatter(env.Organization).Apis, tokenResponse.AccessToken);
            return proxyNames.Select(p => new ApiProxy
            {
                Name = p
            });
        }

        private async Task<T> GetRequest<T>(string uri, string authToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authToken}");
                using (HttpResponseMessage response = await client.GetAsync(uri))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(responseBody);
                }
            }
        }

        private async Task<TOut> GetAuthToken<TOut>(string url, Environment env)
        {
            using (var client = new HttpClient())
            {
                var dict = new Dictionary<string, string>();
                dict["grant_type"] = "password";
                dict["username"] = env.User;
                dict["password"] = env.Password;
                client.DefaultRequestHeaders.Add("Authorization", "Basic ZWRnZWNsaTplZGdlY2xpc2VjcmV0");
                var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(dict) };
                var res = await client.SendAsync(req);
                res.EnsureSuccessStatusCode();
                string responseBody = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TOut>(responseBody);
            }
        }
    }
```