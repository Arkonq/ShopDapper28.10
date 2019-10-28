using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Domain.Repository
{
	public class PurchaseRepository
	{
		static string connectionString = "Server=A-305-04;Database=ShopDbEF_Test;Trusted_Connection=True;";

		public void Add(Purchase purchase)
		{
			var sql = "Insert into Purchases (Id, CreationDate, ItemId, UserId) Values (@Id, @CreationDate, @ItemId, @UserId);";

			using (var connection = new SqlConnection(connectionString))
			{
				var rowAffected = connection.Execute(sql, purchase);
				if (rowAffected != 1)															// так как вставка всего на 1 строку
				{
					throw new Exception("Что-то пошло не так");
				}
			}
		}

		public List<Purchase> GetAll(Guid UserId)
		{
			var sql = "Select * " +
				"From Purchases" +
				"Where UserId = @UserId" +
				"Order by CreationDate";

			using (var connection = new SqlConnection(connectionString))
			{
				return connection.Query<Purchase>(sql, new { UserId = UserId}).ToList();
			}
		}
	}
}
