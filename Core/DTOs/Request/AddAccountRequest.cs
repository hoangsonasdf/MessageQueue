using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Request
{
    public class AddAccountRequest
    {
        public string UserName { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public int StudentId { get; set; }
    }
}
