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
        public Post(uint id, string content, string intro, DateTime dateTime, User user, Role roles)
        {
            Id = id;
            Content = content;
            Intro = intro;
            this.dateTime = dateTime;
            Roles = roles;
            User = user;
        }


        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; }


        [Column("Заголовок Поста", TypeName = "NVARCHAR(50)")]
        string Title { get; set; }


        [Column("Заголовок Поста", TypeName = "NVARCHAR(100)")]
        string Intro { get; set; }


        [Column("Пост", TypeName = "NVARCHAR(100000)")]
        string Content { get; set; }


        [Column("Время Создания", TypeName = "DATETIME")]
        DateTime dateTime = DateTime.Now;


        [Column("Автор")]
        User User { get; set; }


        [Column("Роль")]
        Role Roles { get; set; }
    }
}
