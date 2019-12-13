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
            }
        }
    }
}
