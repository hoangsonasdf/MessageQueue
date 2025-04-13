using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Student : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public int Age { get; set; }
        public string Class { get; set; } = String.Empty;
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
