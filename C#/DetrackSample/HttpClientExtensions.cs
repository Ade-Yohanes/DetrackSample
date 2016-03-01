using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DetrackSample
{
  public static class HttpClientExtensions
  {
    public static async Task<HttpResponseMessage> PostAsJsonWithNoCharSetAsync<T>(this HttpClient client,
      string requestUri, T value, CancellationToken cancellationToken)
    {
      return await client.PostAsync(requestUri, value, new NoCharSetJsonMediaTypeFormatter(), cancellationToken);
    }

    public static async Task<HttpResponseMessage> PostAsJsonWithNoCharSetAsync<T>(this HttpClient client,
      string requestUri, T value)
    {
      return await client.PostAsync(requestUri, value, new NoCharSetJsonMediaTypeFormatter());
    }
  }
}
