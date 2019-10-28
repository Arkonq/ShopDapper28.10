using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Shop.Domain.Repository
{
	public class CategoryRepository
	{
		static string connectionString = "Server=A-305-04;Database=ShopDbEF_Test;Trusted_Connection=True;";

		public int AllCategoriesCount()
		{
			var sql = "Select * From Categories";

			using (var connection = new SqlConnection(connectionString))
			{
				return connection.Query(sql).AsList().Count;
			}
		}

		public int CategoriesOnPage(int page, int pageSize)
		{
			var sql = "Select * From Categories " +
								"ORDER BY (SELECT NULL)" +
								"OFFSET @Skip ROWS " +
								"FETCH NEXT @Take ROWS ONLY; ";
								
			using (var connection = new SqlConnection(connectionString))
			{
				return connection.Query(sql, new { Skip = (page - 1) * pageSize, Take = pageSize}).AsList().Count;
			}
		}
	}
}
