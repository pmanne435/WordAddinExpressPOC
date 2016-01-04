using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Verisk.ISO.Mozart.Web.Controllers
{
    public class Employee
    {
        // [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public ObjectId Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Salary { get; set; }

        public Department DepartmentObj { get; set; }

        public string EmpCVFileID { get; set; }

        [BsonIgnore]
        public byte[] Data { get; set; }

        public string FileName { get; set; }

        //public string FirstName { get; set; }
    }

    public class Department
    {
        //public ObjectId Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentId { get; set; }
    }
}