using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DetrackSample.Models
{
  /// <summary>
  /// Delivery Item model for Add/Edit Deliveries
  /// Mark properties as required as defined by Detrack API
  /// </summary>
  public class DeliveryItem
  {
    [JsonProperty(Required = Required.Always)]
    public string date { get; set; }

    [JsonProperty(Required = Required.Always, PropertyName = "do")]
    public string Do { get; set; }

    [JsonProperty(Required = Required.Always)]
    public string address { get; set; }
    public string delivery_time { get; set; }
    public string deliver_to { get; set; }
    public string phone { get; set; }
    public string notify_email { get; set; }
    public string notify_url { get; set; }
    public string assign_to { get; set; }
    public string instructions { get; set; }
    public string zone { get; set; }
    public List<Item> items { get; set; }
  }
}
