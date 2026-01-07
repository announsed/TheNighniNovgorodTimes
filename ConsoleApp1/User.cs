using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class User : IId
    {
        public User(uint id, string userName, string password, Role? roles)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Roles = roles;
        }

        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; }


        [Column("Имя", TypeName = "CHAR(100)")]
        [Required]
        string UserName { get; set; }


        [Column("Пароль", TypeName = "CHAR(100)")]
        [Required]
        string Password { get; set; }


        [Column("Роль")]
        Role? Roles { get; set; }
    }
}
