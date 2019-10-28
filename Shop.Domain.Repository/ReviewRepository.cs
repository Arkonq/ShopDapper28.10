using Dapper;
using System.Data.SqlClient;
using System;

namespace Shop.Domain.Repository
{
	public class ReviewRepository
	{
		static string connectionString = "Server=A-305-04;Database=ShopDbEF_Test;Trusted_Connection=True;";

		public int ReviewsCount(Guid ResultItemId)
		{
			var sql = "Select * From Reviews " +
				"WHERE ItemId = @ResultItemId";

			using (var connection = new SqlConnection(connectionString))
			{
				return connection.Query(sql, new { ResultItemId = ResultItemId }).AsList().Count;
			}
		}

	}
}
