using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Newsletter
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
