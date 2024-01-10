using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitize.Shared.Data
{
    public class Aadhaar
    {
        public int IdAdhar { get; set; }
        public string?  Name { get; set; }
        public DateTime DOB { get; set; }
        public string? FatherName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int UidNo { get; set; }

    }
}
