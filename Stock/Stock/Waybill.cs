using System;
using System.Collections.Generic;
using System.Text;

namespace Stock
{
  public class Waybill
  {
    public int Id { get; set; }
    public int StockerId { get; set; }
    public string Provider { get; set; }
    public string Receiver { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public DateTime? DepartureDate { get; set; }
    public bool IsExport { get; set; }
  }
}
