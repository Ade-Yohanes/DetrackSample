using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DetrackSample.Models
{
  /// <summary>
  /// DeleryItem model for DeleteDelivery Request
  /// Mark properties as required as defined by Detrack API
  /// </summary>
  public class DeleteDeliveryRequest
  {
    [JsonProperty(Required = Required.Always)]
    public string date { get; set; }

    [JsonProperty(Required = Required.Always, PropertyName = "do")]
    public string Do { get; set; }
  }
}
