using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Roles : IId
    {
        public Roles(uint id, Readers? readers, Writers? writers, Admins? admins)
        {
            Id = id;
            Readers = readers;
            Writers = writers;
            Admins = admins;
        }

        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; }


        [Column("Читатели")]
        Readers? Readers { get; set; }


        [Column("Писатели")]
        Writers? Writers { get; set; }


        [Column("Администраторы")]
        Admins? Admins { get; set; }
    }
}
