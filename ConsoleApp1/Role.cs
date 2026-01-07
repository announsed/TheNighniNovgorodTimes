using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Role : IId
    {
        public Role(uint id, Roles role)
        {
            Id = id;
            Roles = role;
        }

        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; }


        [Column("Роль")]
        Roles Roles { get; set; }
    }


    public enum Roles 
    {
        Читатель,
        Писатель,
        Администратор
    }
}
