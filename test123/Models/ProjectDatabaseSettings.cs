using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test123.Models
{
    public class ProjectDatabaseSettings : IProjectDatabaseSettings
    {
        public string UserLoginCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        /*
         * "ProjectDatabaseSettings": {
            "UserLoginCollection": "user_login",
            "ConnectionString": "mongodb://localhost:27017",
            "DatabaseName" : "project"
          }
         */
    }

    public interface IProjectDatabaseSettings
    {
        public string UserLoginCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
