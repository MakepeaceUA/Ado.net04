using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp49
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=ARSEN;Initial Catalog=CoffeeShop;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Успешное подключение к базе данных.");
                    Console.WriteLine($"Сервер: {connection.DataSource}");
                    Console.WriteLine($"База данных: {connection.Database}");
                    Console.WriteLine("\nДанные из таблицы CoffeeShop:");

                    string query = "SELECT * FROM Coffee";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["id"]}, Название: {reader["coffee_name"]}, Страна: {reader["origin_country"]}, " +
                                              $"Тип: {reader["coffee_type"]},Описание: {reader["description"]}, Граммы: {reader["quantity_grams"]}, Себестоимость: {reader["cost_price"]}");
                        }
                    }

                    Console.WriteLine("\nНазвания всех сортов кофе:");
                    string nameQuery = "SELECT coffee_name FROM Coffee";
                    using (SqlCommand command = new SqlCommand(nameQuery, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["coffee_name"]}");
                        }
                    }

                    string minCostQuery = "SELECT MIN(cost_price) AS MinCost FROM Coffee";
                    using (SqlCommand command = new SqlCommand(minCostQuery, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"\nМинимальная себестоимость: {reader["MinCost"]} у.е.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при подключении или выполнении запроса:");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                        Console.WriteLine("\nПодключение закрыто.");
                    }
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
