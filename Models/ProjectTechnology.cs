using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portifolio.Models
{
    [Table("ProjectTechnology")]
    public class ProjectTechnology
    {
        [Key, Column(Order = 1)]
        public int IdProject { get; set; }

        [ForeignKey("IdProject")]
        public Project? Project { get; set; }

        [Key, Column(Order = 2)]
        public int IdTechnology { get; set; }

        [ForeignKey("IdTechnology")]
        public Technology? Technology { get; set; }
    }
}