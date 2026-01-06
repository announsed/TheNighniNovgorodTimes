using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Admins : IId
    {
        public Admins(uint id, Users? users)
        {
            Id = id;
            Users = users;
        }

        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; }


        [Column("Пользователи")]
        Users? Users { get; set; }
    }
}
