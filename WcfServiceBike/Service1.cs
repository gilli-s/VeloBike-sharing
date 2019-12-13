using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Client;

namespace WcfServiceBike
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private string connectionString = @"Data Source=DESKTOP-R2DBBQN;Initial Catalog=VeloSharing;Integrated Security=True";
        //добавление пинкода
        public void AddPin(string username, string pin)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO PinCodes(Username,PinCode) VALUES(@param1,@param2)";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = username;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = pin;
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                connection.Close();
            }
        }

        //бронирование велосипеда
        public void BookBike(string street, int freebikes)
        {
            string sqlExpression = $"UPDATE Stations SET CountFreeBikes = {freebikes -1} WHERE Street = '{street}' ;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Обновлено объектов: {0}", number);
            }
        }

        //провека юзера в базе данных
        public User CheckUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Select * From [User] where Username ='{username}' and Password = '{password}' ;";
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    User userFromBd = new User();
                    while (reader.Read()) // построчно считываем данные
                    {
                        userFromBd.Username = (string)reader.GetValue(1);
                        userFromBd.FIO = (string)reader.GetValue(2);
                        userFromBd.Birthday = (DateTime)reader.GetValue(3);
                        userFromBd.Passport = (string)reader.GetValue(4);
                        userFromBd.Card = (string)reader.GetValue(5);
                        Console.WriteLine(userFromBd.Username+ " Вошел в приложение");
                    }
                    reader.Close();
                    connection.Close();
                    return userFromBd;
                }
                else
                {
                    reader.Close();
                    connection.Close();
                    return new User();
                }

              

            }
        }
        //добавление юзера в базу данных
        public void InsertIntoUser(string username, string fio, DateTime birthday , string passport, string card, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO [User](Username,FIO,Birthday,Passport,Card,Password) VALUES(@param1,@param2,@param3,@param4,@param5,@param6)";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = username;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = fio;
                    cmd.Parameters.Add("@param3", SqlDbType.Date).Value = birthday;
                    cmd.Parameters.Add("@param4", SqlDbType.VarChar, 50).Value = passport;
                    cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = card;
                    cmd.Parameters.Add("@param6", SqlDbType.VarChar, 50).Value =password;
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                connection.Close();
            }
        }
        //Запрос на выборку всех станций
        public DataSet OutStation()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT * FROM Stations";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Stations");
            con.Close();
            return ds;
        }
    }
}
