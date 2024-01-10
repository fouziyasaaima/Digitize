using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitize.Shared.Data
{
    public class Birth
    {
           public int Id { get; set; }
           public string? Name { get; set; }
           public int  DOB { get; set; }
           public string? FatherName { get; set; }
           public string? MotherName { get; set; }
           public string? Address { get; set; }
           public int RegNo { get; set; }
           public DateTime Approval { get; set; }
           public DateTime Issue { get; set; }
    }
}
