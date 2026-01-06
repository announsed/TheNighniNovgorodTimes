using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Writers : IId
    {
        public Writers(uint id, Users? users, Posts? posts)
        {
            Id = id;
            Users = users;
            Posts = posts;
        }

        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; }


        [Column("Пользователи")]
        Users? Users { get; set; }


        [Column("Посты")]
        Posts? Posts { get; set; }
    }
}
