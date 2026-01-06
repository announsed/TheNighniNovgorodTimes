using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Posts : IId
    {
        public Posts(uint id, string valuePost, DateTime dateTime, Roles roles)
        {
            Id = id;
            ValuePost = valuePost;
            this.dateTime = dateTime;
            Roles = roles;
        }

        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; }


        [Column("Пост", TypeName = "NVARCHAR(100000)")]
        string ValuePost { get; set; }


        [Column("Время Регистрации", TypeName = "DATETIME")]
        DateTime dateTime = DateTime.Now;


        [Column("Роль")]
        Roles Roles { get; set; }
    }
}
