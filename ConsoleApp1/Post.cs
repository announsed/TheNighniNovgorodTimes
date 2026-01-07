using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Post : IId
    {
        public Post(uint id, string valuePost, DateTime dateTime, Role roles)
        {
            Id = id;
            Content = valuePost;
            this.dateTime = dateTime;
            Roles = roles;
        }

        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; }


        [Column("Пост", TypeName = "NVARCHAR(100000)")]
        string Content { get; set; }


        [Column("Время Создания", TypeName = "DATETIME")]
        DateTime dateTime = DateTime.Now;


        [Column("Роль")]
        Role Roles { get; set; }
    }
}
