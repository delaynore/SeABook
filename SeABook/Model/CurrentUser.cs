using SeABook.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeABook.Model
{
    public static class CurrentUser
    {
        public static string Name { get; set; } = "";
        public static string Surname { get; set; } = "";
        public static string Fathername { get; set; } = "";
        public static bool IsAdmin { get; set; }

        public static void UpdateUser(Reader reader)
        {
            Name = reader.Name;
            Surname = reader.Surname;
            Fathername = reader.Fathername;
            IsAdmin = reader.Account.Admin;
        }
    }
}
