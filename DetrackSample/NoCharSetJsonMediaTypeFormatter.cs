using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace DetrackSample
{
  public class NoCharSetJsonMediaTypeFormatter : JsonMediaTypeFormatter
  {
    public override void SetDefaultContentHeaders(Type type, System.Net.Http.Headers.HttpContentHeaders headers,
      System.Net.Http.Headers.MediaTypeHeaderValue mediaType)
    {
      base.SetDefaultContentHeaders(type, headers, mediaType);
      headers.ContentType.CharSet = "";
    }
  }
}
