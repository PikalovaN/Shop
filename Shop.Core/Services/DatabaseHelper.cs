using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace Shop.Core.Services
{
    public class DatabaseHelper
    {
        OleDbConnection? _c;
        const string _connectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=Магазин.accdb";

        public async Task<List<Product>> GetProducts()
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            List<Product> products = new List<Product>();
            OleDbCommand cmd = new OleDbCommand("SELECT [BookId],[Наименование],[Возрастное ограничение].[Возраст],[Дата производства].[Год],[Производители].[Производитель],[Цена],[В заказе],[Пришло],[Выдано],[Тематическая подборка].[Тематика],[Категории товаров].[Категория] " +
                                                    "FROM [Товары],[Дата производства],[Производители],[Тематическая подборка],[Возрастное ограничение],[Категории товаров] " +
                                                        "WHERE [Товары].[год] = [Дата производства].[№дат] " +
                                                            "AND [Товары].[Производитель] = [Производители].[№произ] " +
                                                                "AND [Товары].[Тематика] = [Тематическая подборка].[№тем] " +
                                                                    "AND [Товары].[Возрастное ограничение] = [Возрастное ограничение].[№воз] " +
                                                                        "AND [Товары].[Категория] = [Категории товаров].[№кат]", _c);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(reader[0]);
                product.Name = Convert.ToString(reader[1]);
                product.Age = Convert.ToString(reader[2]);
                product.Year = Convert.ToInt32(reader[3]);
                product.Manufacturer = Convert.ToString(reader[4]);
                product.Price = Convert.ToDecimal(reader[5]);
                product.Count = Convert.ToInt32(reader[6]);
                product.In = Convert.ToInt32(reader[7]);
                product.Out = Convert.ToInt32(reader[8]);
                product.Subject = Convert.ToString(reader[9]);
                product.Category = Convert.ToString(reader[10]);
                products.Add(product);
                
            }
            reader.Close();
            await _c.CloseAsync();
            return products;
        }
        public async Task<List<Product>> GetProducts(int orderNumber)
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            List<Product> products = new List<Product>();
            OleDbCommand cmd = new OleDbCommand("SELECT [Товары в заказах].[BookId],[Наименование],[Возрастное ограничение].[Возраст],[Дата производства].[Год],[Производители].[Производитель],[Цена],[В заказе],[Пришло],[Выдано],[Тематическая подборка].[Тематика],[Категории товаров].[Категория] " +
                                                    "FROM [Товары в заказах],[Товары],[Дата производства],[Производители],[Тематическая подборка],[Возрастное ограничение],[Категории товаров] " +
                                                        "WHERE [Товары].[год] = [Дата производства].[№дат] " +
                                                            "AND [Товары].[Производитель] = [Производители].[№произ] " +
                                                                "AND [Товары].[Тематика] = [Тематическая подборка].[№тем] " +
                                                                    "AND [Товары].[Возрастное ограничение] = [Возрастное ограничение].[№воз] " +
                                                                        "AND [Товары].[Категория] = [Категории товаров].[№кат] " +
                                                                            "AND [Товары в заказах].[BookId]=[Товары].[BookId] " +
                                                                                "AND [Товары в заказах].[Заказ]=" + '"' + orderNumber.ToString() + '"', _c);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(reader[0]);
                product.Name = Convert.ToString(reader[1]);
                product.Age = Convert.ToString(reader[2]);
                product.Year = Convert.ToInt32(reader[3]);
                product.Manufacturer = Convert.ToString(reader[4]);
                product.Price = Convert.ToDecimal(reader[5]);
                product.Count = Convert.ToInt32(reader[6]);
                product.In = Convert.ToInt32(reader[7]);
                product.Out = Convert.ToInt32(reader[8]);
                product.Subject = Convert.ToString(reader[9]);
                product.Category = Convert.ToString(reader[10]);
                products.Add(product);

            }
            reader.Close();
            await _c.CloseAsync();
            return products;
        }
        public async Task<List<Order>> GetOrders()
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            List<Order> orders = new List<Order>();
            OleDbCommand cmd = new OleDbCommand("SELECT [Заказ],[IDкл],[Дата приемки],[Хранится до],[Услуги].[Тип услуги],[Способ оплаты].[Оплата],[Доставка].[Состояние доставки],[Город].[Город],[Адрес].[Адрес] " +
                                                    "FROM [Заказы],[Услуги],[Способ оплаты],[Доставка],[Город],[Адрес] " +
                                                        "WHERE [Заказы].[Услуга]=[Услуги].[№усл] " +
                                                            "AND [Заказы].[Оплата]=[Способ оплаты].[№оп] " +
                                                                "AND [Заказы].[Доставка]=[Доставка].[№дос] " +
                                                                    "AND [Заказы].[Город]=[Город].[№гор] " +
                                                                        "AND [Заказы].[Адрес]=[Адрес].[№адр]", _c);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Order order = new Order();
                order.Id = Convert.ToInt32(reader[0]);
                order.ClientId = Convert.ToInt32(reader[1]);
                order.Start = Convert.ToDateTime(reader[2]);
                order.End = Convert.ToDateTime(reader[3]);
                order.Service = Convert.ToString(reader[4]);
                order.Payment = Convert.ToString(reader[5]);
                order.Delivery = Convert.ToString(reader[6]);
                order.City = Convert.ToString(reader[7]);
                order.Address = Convert.ToString(reader[8]);
                orders.Add(order);
            }
            reader.Close();
            await _c.CloseAsync();
            return orders;
        }
        public async Task<List<Client>> GetClients()
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            List<Client> clients = new List<Client>();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Клиент]", _c);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Client client = new Client();
                client.Id = Convert.ToInt32(reader[0]);
                client.LName = Convert.ToString(reader[1]);
                client.Name = Convert.ToString(reader[2]);
                client.Otch = Convert.ToString(reader[3]);
                client.Email = Convert.ToString(reader[4]);
                client.Phone = Convert.ToString(reader[5]);
                clients.Add(client);
            }
            reader.Close();
            await _c.CloseAsync();
            return clients;
        }
    }
}
