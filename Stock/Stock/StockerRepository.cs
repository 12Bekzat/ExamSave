using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Stock
{
  public class StockerRepository
  {
    private readonly string connectionString;
    public StockerRepository(string connectionString)
    {
      this.connectionString = connectionString;
    }

    public void Insert(Stocker stocker)
    {
      using(var connection = new SqlConnection(connectionString))
      {
        connection.Insert(stocker);
      }
    }

    public void Update(Stocker stocker)
    {
      using (var connection = new SqlConnection(connectionString))
      {
        connection.Update(stocker);
      }
    }

    public void Delete(Stocker stocker)
    {
      using (var connection = new SqlConnection(connectionString))
      {
        connection.Delete(stocker);
      }
    }

    public ICollection<Stocker> GetStockers()
    {
      string sql = "Select * from Stockers;";
      using (var connection = new SqlConnection(connectionString))
      {
        return connection.Query<Stocker>(sql).ToList();
      }
    }
  }
}
