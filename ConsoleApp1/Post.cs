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
        public Post(uint id, string title, string content, string intro, DateTime dateTime, List<User> autors, Role roles)
        {
            Id = id;
            Content = content;
            Title = title;
            Intro = intro;
            this.dateTime = dateTime;
            Roles = roles;
            Autors = autors;
        }


        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; }


        [Column("Заголовок Поста", TypeName = "NVARCHAR(50)")]
        public string Title { get; set; }


        [Column("Заголовок Поста", TypeName = "NVARCHAR(100)")]
        public string Intro { get; set; }


        [Column("Пост", TypeName = "NVARCHAR(100000)")]
        public string Content { get; set; }


        [Column("Время Создания", TypeName = "DATETIME")]
        public DateTime dateTime = DateTime.Now;


        [Column("Автор")]
        public List<User> Autors { get; init; }


        [Column("Роль")]
        public Role Roles { get; set; }
    }
}
