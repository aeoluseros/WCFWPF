using System;
using System.Runtime.Serialization;

namespace FirstServer {
    [DataContract]
    public class Employee {
        [DataMember]
        public int BusinessEntityID { get; set; }
        [DataMember]
        public string NationalIDNumber { get; set; }
        [DataMember]
        public string LoginID { get; set; }
        [DataMember]
        public string OrganizationNode { get; set; }
        [DataMember]
        public int OrganizationLevel { get; set; }
        [DataMember]
        public string JobTitle { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public string MaritalStatus { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public DateTime HireDate { get; set; }
        [DataMember]
        public string SalariedFlag { get; set; }
        [DataMember]
        public int VacationHours { get; set; }
        [DataMember]
        public int SickLeaveHours { get; set; }
        [DataMember]
        public string CurrentFlag { get; set; }
        [DataMember]
        public Guid RowGuid { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
    }
}