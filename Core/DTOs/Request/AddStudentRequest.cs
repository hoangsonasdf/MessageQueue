using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Request
{
    public class AddStudentRequest
    {
        public string Name { get; set; } = String.Empty;
        public int Age { get; set; }
        public string Class { get; set; } = String.Empty;
    }
}
