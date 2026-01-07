using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Reader : IId
    {
        public Reader(uint id, User users, Post? posts)
        {
            Id = id;
            Users = users;
            Posts = posts;
        }

        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; }


        [Column("Пользователи")]
        User Users { get; set; }


        [Column("Посты")]
        Post? Posts { get; }
    }
}
