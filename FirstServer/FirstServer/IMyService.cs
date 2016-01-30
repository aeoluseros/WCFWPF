using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;  //important!

namespace FirstServer {
    [ServiceContract]
    interface IMyService
    {
        [OperationContract]
        string GetData();

        [OperationContract]
        string GetMessage(string name);

        [OperationContract]
        //string GetResult(int sid, string sName, int m1, int m2, int m3);
        string GetResult(Student s);

        [OperationContract]
        int GetMax(int[] ar);

        [OperationContract]
        int[] GetSorted(int[] ar);

        [OperationContract]
        Student GetTopper(List<Student> LS);

        [OperationContract]
        List<Employee> GetAllEmployees();
    }
}
