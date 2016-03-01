using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetrackApi.Model
{
  public class Delivery
  {
    public DateTime date { get; set; }
    public string address { get; set; }
    public string delivery_time { get; set; }
    public string deliver_to { get; set; }
    public string phone { get; set; }
    public string notify_email { get; set; }
    public string notify_url { get; set; }
    public string assign_to { get; set; }
    public string instructions { get; set; }
    public string zone { get; set; }
    public string reason { get; set; }
    public string note { get; set; }
    public string received_by { get; set; }
    public string image { get; set; }
    public string view_image_url { get; set; }
    public string Do { get; set; }
    public string status { get; set; }
    public string time { get; set; }
    public string pod_lat { get; set; }
    public string pod_lng { get; set; }
    public string pod_address { get; set; }
  }
}
