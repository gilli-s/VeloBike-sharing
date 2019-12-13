using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Client;

namespace WcfServiceBike
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void AddPin(string username,string pin);
        [OperationContract]
        void BookBike(string street, int freebikes );
        [OperationContract]
        DataSet OutStation();
        [OperationContract]
        void InsertIntoUser(string username, string fio, DateTime date, string passport, string card, string password);
        [OperationContract]
        User CheckUser(string username, string password);
    }
}
