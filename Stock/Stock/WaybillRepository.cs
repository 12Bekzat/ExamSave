using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Stock
{
  public class WaybillRepository
  {
    private readonly string connectionString;
    public WaybillRepository(string connectionString)
    {
      this.connectionString = connectionString;
    }

    public void Add(Waybill waybill)
    {
      using(var connection = new SqlConnection(connectionString))
      {
        connection.Insert(waybill);
      }
    }

    public void Update (Waybill waybill)
    {
      using(var connection = new SqlConnection(connectionString))
      {
        connection.Update(waybill);
      }
    }

    public void Delete(Waybill waybill)
    {
      using(var connection = new SqlConnection(connectionString))
      {
        connection.Delete(waybill);
      }
    }

    public ICollection<Waybill> GetAll()
    {
      string sql = "Select * from Waybills;";
      using(var connection = new SqlConnection(connectionString))
      {
        return connection.Query<Waybill>(sql).ToList();
      }
    }
  }
}
