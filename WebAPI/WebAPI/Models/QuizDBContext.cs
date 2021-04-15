using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class QuizDBContext:DbContext
    {
        public QuizDBContext(DbContextOptions<QuizDBContext> options):base(options)
        {

        }

        public DbSet<DQuestion> DQuestions { get; set; }
    }

}
