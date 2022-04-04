
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyProjectStart.Models
{
      public  class UserModel
     {
        [SQLite.PrimaryKey, AutoIncrement] 
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirtDay { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
    }
}
