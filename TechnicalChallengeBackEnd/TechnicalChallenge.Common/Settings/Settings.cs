using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalChallenge.Common.Settings
{
    public class TechnicalChallengeSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings 
    { 
        public UsersConnectionString UsersConnectionString { get; set; }
    }

    public class UsersConnectionString : ConnectionString
    {
    }

    public class ConnectionString 
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

}
