using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Controls;

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
            
           using OleDbDataReader reader = cmd.ExecuteReader();
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
        public async Task<List<Product>> GetProductsZ(int productId)
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();

            List<Product> products = new List<Product>();

           OleDbCommand cmd = new OleDbCommand("SELECT [Товары].[BookId],[Наименование],[Возрастное ограничение].[Возраст],[Дата производства].[Год],[Производители].[Производитель],[Цена],[В заказе],[Пришло],[Выдано],[Тематическая подборка].[Тематика],[Категории товаров].[Категория] " +
                                        "FROM [Товары],[Дата производства],[Производители],[Тематическая подборка],[Возрастное ограничение],[Категории товаров] " +
                                            "WHERE [Товары].[год] = [Дата производства].[№дат] " +
                                                "AND [Товары].[Производитель] = [Производители].[№произ] " +
                                                    "AND [Товары].[Тематика] = [Тематическая подборка].[№тем] " +
                                                        "AND [Товары].[Возрастное ограничение] = [Возрастное ограничение].[№воз] " +
                                                            "AND [Товары].[Категория] = [Категории товаров].[№кат] " +
                                                                
                                                                    "AND [Товары].[BookId]=" + "'" + productId.ToString() + "'", _c);
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
        public async Task AddProduct(Product product)
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            OleDbCommand cmd = new OleDbCommand("SELECT [№воз],[№дат],[№произ],[№тем],[№кат] FROM [Возрастное ограничение],[Дата производства],[Производители],[Тематическая подборка],[Категории товаров] WHERE [Возрастное ограничение].[Возраст] = " + '"' + product.Age + '"' + " " +
                                                    "AND [Дата производства].[Год] = " + product.Year + " " +
                                                        "AND [Производители].[Производитель] = " + '"' + product.Manufacturer + '"' + " " +
                                                            "AND [Тематическая подборка].[Тематика] = " + '"' + product.Subject + '"' + " " +
                                                                "AND [Категории товаров].[Категория] = " + '"' + product.Category + '"', _c);
            using OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();
            cmd = new OleDbCommand("INSERT INTO [Товары]([BookId],[Наименование],[Возрастное ограничение],[год],[Производитель],[Цена],[В заказе],[Пришло],[Выдано],[Тематика],[Категория]) " +
                                    "VALUES(" + product.Id + ',' + '"' + product.Name + '"' + ',' + Convert.ToInt32(reader[0]) + ',' + Convert.ToInt32(reader[1]) + ',' + Convert.ToInt32(reader[2]) + ',' + product.Price + ',' + product.Count + ',' + product.In + ',' + product.Out + ',' + Convert.ToInt32(reader[3]) + ',' + Convert.ToInt32(reader[4]) + ')', _c);
            cmd.ExecuteNonQuery();
            reader.Close();
            await _c.CloseAsync();
        }
        public async Task RemoveProduct(Product product)
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            OleDbCommand cmd = new OleDbCommand("DELETE FROM [Товары] WHERE [BookId] = " + '"' + product.Id + '"', _c);
            cmd.ExecuteNonQuery();
            await _c.CloseAsync();
        }
        public async Task UpdateProduct(Product product)
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            OleDbCommand cmd = new OleDbCommand("SELECT [№воз],[№дат],[№произ],[№тем],[№кат] FROM [Возрастное ограничение],[Дата производства],[Производители],[Тематическая подборка],[Категории товаров] WHERE [Возрастное ограничение].[Возраст] = " + '"' + product.Age + '"' + " " +
                                                    "AND [Дата производства].[Год] = " + product.Year + " " +
                                                        "AND [Производители].[Производитель] = " + '"' + product.Manufacturer + '"' + " " +
                                                            "AND [Тематическая подборка].[Тематика] = " + '"' + product.Subject + '"' + " " +
                                                                "AND [Категории товаров].[Категория] = " + '"' + product.Category + '"', _c);
            using OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();
            cmd = new OleDbCommand("UPDATE  [Товары] " +
                                        "SET [Наименование] = " + '"' + product.Name + '"' + ", [Возрастное ограничение] = " + Convert.ToInt32(reader[0]) + ", [год] = " + Convert.ToInt32(reader[1]) + ", [Производитель] = " + Convert.ToInt32(reader[2]) + ", [Цена] = " + product.Price + ", [В заказе] = " + product.Count + ", [Пришло] = " + product.In + ", [Выдано] = " + product.Out + ", [Тематика] = " + Convert.ToInt32(reader[3]) + ", [Категория] = " + Convert.ToInt32(reader[4]) + " " +
                                            "WHERE [BookId] = " + '"' + product.Id + '"', _c);
            cmd.ExecuteNonQuery();
            reader.Close();
            await _c.CloseAsync();
        }
        public async Task AddClients( Client client)
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();


            OleDbCommand cmd = new OleDbCommand("INSERT INTO [Клиент]([№кл],[Фамилия],[Имя],[Отчество],[Почта],[Телефон]) " +
                                    "VALUES(" + client.Id + ',' + '"' + client.LName.ToString() + '"' + ',' + '"' + client.Name.ToString() + '"' + ',' + '"' + client.Otch.ToString() + '"' + ',' + '"' + client.Email.ToString() + '"' + ',' + '"' + client.Phone.ToString() + '"' + ')', _c);
            using OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();
            //cmd.ExecuteNonQuery();
            reader.Close();
            await _c.CloseAsync();
        }
        public async Task RemoveClients(Client client)
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            OleDbCommand cmd = new OleDbCommand("DELETE FROM [Клиент] WHERE [№кл] = "  + client.Id , _c);
            cmd.ExecuteNonQuery();
            await _c.CloseAsync();
        }
        public async Task UpdateClients(Client client)
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
           
            OleDbCommand cmd = new OleDbCommand("UPDATE  [Клиент] " +
                                        "SET  [Фамилия] = " + '"' + client.LName + '"'+ ", [Имя] = " + '"' + client.Name + '"' + ", [Отчество] = " + '"' + client.Otch + '"' + ", [Почта] = " + '"' + client.Email + '"' + ", [Телефон] = " + '"' + client.Phone + '"' +
                                            " WHERE [№кл] = " +  client.Id , _c);
            using OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();
            reader.Close();
            await _c.CloseAsync();
        }

        public async Task<List<string>> GetAges()
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            List<string> ages = new List<string>();
            OleDbCommand cmd = new OleDbCommand("SELECT [Возраст] " +
                                                    "FROM [Возрастное ограничение]", _c);

            using OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                ages.Add(Convert.ToString(reader[0]));
            reader.Close();
            await _c.CloseAsync();
            return ages;
        }
        public async Task<List<string>> GetManufacturers()
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            List<string> manufacturers = new List<string>();
            OleDbCommand cmd = new OleDbCommand("SELECT [Производитель] " +
                                                    "FROM [Производители]", _c);

            using OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                manufacturers.Add(Convert.ToString(reader[0]));
            reader.Close();
            await _c.CloseAsync();
            return manufacturers;
        }
        public async Task<List<string>> GetYears()
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            List<string> years = new List<string>();
            OleDbCommand cmd = new OleDbCommand("SELECT [Год] " +
                                                    "FROM [Дата производства]", _c);

            using OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                years.Add(Convert.ToString(reader[0]));
            reader.Close();
            await _c.CloseAsync();
            return years;
        }
            public async Task<List<string>> GetSubjects()
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            List<string> subjects = new List<string>();
            OleDbCommand cmd = new OleDbCommand("SELECT [Тематика] " +
                                                    "FROM [Тематическая подборка]", _c);

            using OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                subjects.Add(Convert.ToString(reader[0]));
            reader.Close();
            await _c.CloseAsync();
            return subjects;
        }
        public async Task<List<string>> GetCategorys()
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            List<string> categorys = new List<string>();
            OleDbCommand cmd = new OleDbCommand("SELECT [Категория] " +
                                                    "FROM [Категории товаров]", _c);

            using OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                categorys.Add(Convert.ToString(reader[0]));
            reader.Close();
            await _c.CloseAsync();
            return categorys;
        }



        public async Task<List<Product>> SearchProducts(string field, string v)
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            List<Product> products = new List<Product>();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = _c;
            if (field != "В заказе" && field != "Пришло" && field != "Выдано" && field != "BookId" && field != "Цена")
            {
                cmd.CommandText = "SELECT [BookId],[Наименование],[Возрастное ограничение].[Возраст],[Дата производства].[Год],[Производители].[Производитель],[Цена],[В заказе],[Пришло],[Выдано],[Тематическая подборка].[Тематика],[Категории товаров].[Категория] " +
                                                    "FROM [Товары],[Дата производства],[Производители],[Тематическая подборка],[Возрастное ограничение],[Категории товаров] " +
                                                        "WHERE [Товары].[год] = [Дата производства].[№дат] " +
                                                            "AND [Товары].[Производитель] = [Производители].[№произ] " +
                                                                "AND [Товары].[Тематика] = [Тематическая подборка].[№тем] " +
                                                                    "AND [Товары].[Возрастное ограничение] = [Возрастное ограничение].[№воз] " +
                                                                        "AND [Товары].[Категория] = [Категории товаров].[№кат] " +
                                                                            "AND " + "[" + field + "] = " + '"' + v + '"';
            }
            else
            {
                cmd.CommandText = "SELECT [BookId],[Наименование],[Возрастное ограничение].[Возраст],[Дата производства].[Год],[Производители].[Производитель],[Цена],[В заказе],[Пришло],[Выдано],[Тематическая подборка].[Тематика],[Категории товаров].[Категория] " +
                                                    "FROM [Товары],[Дата производства],[Производители],[Тематическая подборка],[Возрастное ограничение],[Категории товаров] " +
                                                        "WHERE [Товары].[год] = [Дата производства].[№дат] " +
                                                            "AND [Товары].[Производитель] = [Производители].[№произ] " +
                                                                "AND [Товары].[Тематика] = [Тематическая подборка].[№тем] " +
                                                                    "AND [Товары].[Возрастное ограничение] = [Возрастное ограничение].[№воз] " +
                                                                        "AND [Товары].[Категория] = [Категории товаров].[№кат] " +
                                                                            "AND " + "[" + field + "] = " + v;
            }
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

        public async Task<List<Client>> SearchClients(string field, string v)
        {
            _c = new OleDbConnection(_connectionString);
            await _c.OpenAsync();
            List<Client> clients = new List<Client>();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = _c;
            if (field == "№кл" || field == "Фамилия" || field == "Имя" || field == "Отчество" || field == "Телефон" || field == "Почта")
            {
                // Ищем столбец, соответствующий field, и потом ищем значение v в этом столбце
                cmd.CommandText = "SELECT [№кл],[Фамилия],[Имя],[Отчество],[Почта],[Телефон]" +
                                        "FROM [Клиент] " +
                                            "WHERE " + "[" + field + "] = " + '"' + v + '"';
            }
            else
            {
                Console.WriteLine("Неверный запрос. Поле должно быть одним из: №кл, Фамилия, Имя, Отчество, Телефон, Почта");
                return clients;
            }
            ////if (field == "№кл" && field == "Фамилия" && field == "Имя" && field == "Отчество" && field == "Телефон" && field == "Почта")
            ////{
            //    cmd.CommandText = "SELECT [№кл],[Фамилия],[Имя],[Отчество],[Почта],[Телефон] " +
            //                                        "FROM [Клиент]" +                                                      
            //                                              "AND " + "[" + field + "] = " + '"' + v + '"';     = " + '"' + product.Id + '"'
            ////}

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
