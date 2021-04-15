using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class DQuestion
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string questionText { get; set; }

        [Column(TypeName = "nvarchar(160)")]
        public string answers { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string correctAnswers { get; set; }
    }
}
