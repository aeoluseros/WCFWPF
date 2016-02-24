using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TransactionLibrary {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(TransactionIsolationLevel = System.Transactions.IsolationLevel.Serializable, TransactionTimeout ="00:00:30",
        InstanceContextMode = InstanceContextMode.PerSession, TransactionAutoCompleteOnSessionClose =true)]
    public class TransactionService : ITransactionService
    {
        //public int CreateEmployee(Employee e){
        private int Eid = 0;
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void CreateEmployee(Employee e){
            //int Eid = 0;
            var con = new SqlConnection("Data Source=.;Initial Catalog=NETTest;Integrated Security=True");
            var cmd =
                new SqlCommand("INSERT INTO EMPLOYEE(EName,ESalary) VALUES(@EName, @ESalary); SELECT SCOPE_IDENTITY()",
                    con);
            cmd.Parameters.AddWithValue("@EName", e.EName);
            cmd.Parameters.AddWithValue("@ESalary", e.ESalary);
            con.Open();
            SqlDataReader employeeReader = cmd.ExecuteReader();
            if (employeeReader.Read()){
                Eid = int.Parse(employeeReader[0].ToString());
            }
            employeeReader.Close();
            con.Close();
            //return Eid;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void CreateSalaryHistory(SalaryHistory sh)
        {
            var con = new SqlConnection("Data Source=.;Initial Catalog=NETTest;Integrated Security=True");
            var cmd =
                new SqlCommand(
                    "INSERT INTO SalaryHistory(Eid, ESalary, StDate, EndDate) VALUES(@Eid, @ESalary, @StDate, NULL)",
                    con);
            cmd.Parameters.AddWithValue("@Eid", sh.Eid);
            cmd.Parameters.AddWithValue("@ESalary", sh.ESalary);
            cmd.Parameters.AddWithValue("@StDate", sh.StDate);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
