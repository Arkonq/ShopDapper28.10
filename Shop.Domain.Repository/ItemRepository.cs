using Dapper;
using System;
using System.Data.SqlClient;

namespace Shop.Domain.Repository
{
	public class ItemRepository
	{
		static string connectionString = "Server=A-305-04;Database=ShopDbEF_Test;Trusted_Connection=True;";

		public int ItemsOnPage(int page, int pageSize)
		{
			var sql = "Select * From Items " +
								"ORDER BY (SELECT NULL)" +
								"OFFSET @Skip ROWS " +
								"FETCH NEXT @Take ROWS ONLY; ";

			using (var connection = new SqlConnection(connectionString))
			{
				return connection.Query(sql, new { Skip = (page - 1) * pageSize, Take = pageSize }).AsList().Count;
			}
		}

		public int GetQuantity(Guid ResultItemId)
		{
			var sql = "Select Quantity From Items " +
								"Where Id = @ResultItemId";

			using (var connection = new SqlConnection(connectionString))
			{
				return connection.QuerySingleOrDefault<int>(sql, new { ResultItemId = ResultItemId});
			}
		}

		public int GetPrice(Guid ResultItemId)
		{
			var sql = "Select Price From Items " +
								"Where Id = @ResultItemId";

			using (var connection = new SqlConnection(connectionString))
			{
				return connection.QuerySingleOrDefault<int>(sql, new { ResultItemId = ResultItemId });
			}
		}
	}
}
