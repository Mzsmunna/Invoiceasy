using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.Entity
{
    public class UserEntity : IEntity
    {
        public int Sl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Usertype { get; set; }
        public string Permission { get; set; }
    }
}
