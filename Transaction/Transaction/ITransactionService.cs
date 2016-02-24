using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TransactionLibrary {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ITransactionService {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        int CreateEmployee(Employee e);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void CreateSalaryHistory(SalaryHistory sh);
    }

    [DataContract]
    public class SalaryHistory
    {
        [DataMember]
        public int Eid { get; set; }
        [DataMember]
        public double ESalary { get; set; }
        [DataMember]
        public DateTime StDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
    }

    [DataContract]
    public class Employee
    {
        [DataMember]
        public string EName { get; set; }
        [DataMember]
        public double ESalary { get; set; }
    }

}
