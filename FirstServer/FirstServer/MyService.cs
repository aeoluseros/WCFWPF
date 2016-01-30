using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstServer {
    public class MyService :IMyService{
        public string GetData()
        {
            return "www.manzoorthetrainer.com";
        }

        public string GetMessage(string name)
        {
            return "Hello Mr./Mrs." + name;
        }

        //public string GetResult(int sid, string sName, int m1, int m2, int m3)
        //{
        //    double avg = (m1 + m2 + m3)/3.0;
        //    if (avg < 35) return "Fail";
        //    else return "Pass";
        //}
        public string GetResult(Student s)
        {
            double avg = (s.M1 + s.M2 + s.M3) / 3.0;
            if (avg < 35) return "Fail";
            else return "Pass";
        }


        public int GetMax(int[] ar)
        {
            //int max = ar[0];
            //for (int i = 0; i < ar.Length; i++)
            //{
            //    if (ar[i] > max)
            //        max = ar[i];
            //}
            //return max;
            return ar.Max();
        }

        public int[] GetSorted(int[] ar)
        {
            Array.Sort(ar);   //in-place sorting
            return ar;
        }

        public Student GetTopper(List<Student> LS)
        {
            List<double> avgScore = LS.Select(std => (std.M1 + std.M2 + std.M3)/3.0).ToList();
            double max = avgScore.Max();
            return LS[avgScore.IndexOf(max)];
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> LC = new List<Employee>();
            string ConStr =
                @"Data Source=aeon;Initial Catalog=AdventureWorks2012;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConStr);
            SqlCommand cmd = new SqlCommand("Select Top 10 * From HumanResources.Employee",con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employee c = new Employee
                {
                    BusinessEntityID = int.Parse(dr[0].ToString()),
                    NationalIDNumber = dr[1].ToString(),
                    LoginID = dr[2].ToString(),
                    OrganizationNode = dr[3].ToString(),
                    OrganizationLevel = int.Parse(dr[4].ToString()),
                    JobTitle = dr[5].ToString()
                };
                LC.Add(c);
            }
            dr.Close();
            con.Close();
            return LC;
        }
    }
}
