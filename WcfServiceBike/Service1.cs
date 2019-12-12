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
    public class Service1 : IService1
    {
        string connectionString = "";
        public void InsertIntoUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO User (Username,FIO,Birthday,Passport,Card) VALUES(@param1,@param2,@param3,@param4,@param5)";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = user.Username;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = user.FIO;
                    cmd.Parameters.Add("@param3", SqlDbType.Date, 50).Value = user.Birthday;
                    cmd.Parameters.Add("@param4", SqlDbType.VarChar, 50).Value = user.Passport;
                    cmd.Parameters.Add("@param5", SqlDbType.Int, 50).Value = user.Card;
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
