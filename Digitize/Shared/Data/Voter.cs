using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitize.Shared.Data
{
    public class Voter
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FatherName { get; set; }
        public string? Address { get; set; }
        public int Phone { get; set; }
        public DateTime DOB { get; set; }
        public int VoterId { get; set; }

        public static implicit operator Voter(Birth v)
        {
            throw new NotImplementedException();
        }
    }
}
