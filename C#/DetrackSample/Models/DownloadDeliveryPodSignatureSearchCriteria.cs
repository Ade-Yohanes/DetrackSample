using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetrackSample.Models
{
  /// <summary>
  /// Model to send with DOWNLOAD DELIVERY POD SIGNATURE IMAGE FILE
  /// Mark field required as defined by Detrack api definition
  /// </summary>
  public class DownloadDeliveryPodSignatureSearchCriteria
  {
    [JsonProperty(Required = Required.Always)]
    public string date { get; set; }

    [JsonProperty(Required = Required.Always, PropertyName = "do")]
    public string Do { get; set; }
  }
}
