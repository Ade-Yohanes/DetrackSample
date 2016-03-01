using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DetrackSample.Models
{
  /// <summary>
  /// Model to send along with ViewAllDeliveries request.
  /// </summary>
  public class ViewAllDeliveries
  {
    /// <summary>
    /// The delivery date. Format: YYYY-MM-DD e.g. 2014-02-28. Required field.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string date { get; set; }
  }
}
