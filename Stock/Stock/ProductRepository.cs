using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Stock
{
  public class ProductRepository
  {
    private readonly string connectionString;
    public ProductRepository(string connectionString)
    {
      this.connectionString = connectionString;
    }

    public void Insert(Product product)
    {
      using(var connection = new SqlConnection(connectionString))
      {
        connection.Insert(product);
      }
    }

    public void Update(Product product)
    {
      using (var connection = new SqlConnection(connectionString))
      {
        connection.Update(product);
      }
    }

    public void Delete(Product product)
    {
      using (var connection = new SqlConnection(connectionString))
      {
        connection.Delete(product);
      }
    }

    public ICollection<Product> GetProducts()
    {
      string sql = "Select * from Products;";
      using(var connection = new SqlConnection(connectionString))
      {
        return connection.Query<Product>(sql).ToList();
      }
    }
  }
}
