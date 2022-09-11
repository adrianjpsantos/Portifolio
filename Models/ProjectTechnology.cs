using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Models
{
    [Table("ProjectTechnology")]
    public class ProjectTechnology
    {
        [Key, Column(Order = 1)]
        public int idProject { get; set; }

        [ForeignKey("idProject")]
        public Project project { get; set; } = new();

        [Key, Column(Order = 2)]
        public int idTechnology { get; set; }

        [ForeignKey("idTechnology")]
        public Technology technology { get; set; } = new();
    }
}