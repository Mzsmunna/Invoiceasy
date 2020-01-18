using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoiceasy.ViewModel
{
    public class UserModel
    {
        public string Sl { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Usertype { get; set; }
        public string Access { get; set; }
    }

    public sealed class UserModelMap : ClassMap<UserModel>
    {
        public UserModelMap()
        {
            Map(m => m.Sl).Name("Sl", "id", "ID", "SL", "Id", "sl");
            Map(m => m.Username).Name("Username", "username", "name", "Name");
            Map(m => m.FirstName).Name("FirstName", "First Name", "first name");
            Map(m => m.LastName).Name("LastName", "Last Name", "last name");
            Map(m => m.Gender).Name("Gender", "gender");
            Map(m => m.DOB).Name("DOB", "dob", "Birth Date", "Date of Birth", "birth date", "date of birth", "birth day", "Birth Day");
            Map(m => m.Email).Name("Email", "email");
            Map(m => m.Phone).Name("Phone", "phone", "Mobile Number", "mobile number", "Number", "number");
            Map(m => m.Password).Name("Password", "password");
            Map(m => m.Usertype).Name("Usertype", "usertype", "User Type", "user type");
            Map(m => m.Access).Name("Access", "Permission", "permission", "access");
            //Map(m => m.Id).Ignore();
        }
    }
}
