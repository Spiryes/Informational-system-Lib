using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Informational_system_Lib.Models
{
    public class BookContext : DbContext //Прави се клас наследник на DbContext който ще помогне за създаването на базата данни в MS Sql
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) // Създава се конструктор използвайки настройките на DbContext
        { }
        public DbSet<Book> Books { get; set; } //създава се DbContext Configuration  и иметао на тази променлива ще бъде името на  нашета таблица.
          // след като връзките във appsettings.json са направени и използвани в Startup.cs можем да направим миграциите и да актоализираме базите данни.
          //чрез Package Manager Console  ще направим миграцията и актуализирането на базата данни задавайки използването на BookContext като контекст клас.
          //след което  Microsoft.EntityFrameworkCore.Tools   ще генерира код за контолерите и изгледите използвайки моделния клас и контекст класът.
    }
}
