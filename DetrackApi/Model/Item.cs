using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetrackApi.Model
{
  public class Item
  {
    public string Sku { get; set; }
    public string Desc { get; set; }
    public int qty { get; set; }
    public int reject { get; set; }
    public string reason { get; set; }
  }
}
