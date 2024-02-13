using System.ComponentModel.DataAnnotations;

namespace Nugatory.Models
{
    public class WordColor
    {
        public int Id { get; set; }
        [Required]
        public string Word { get; set; }
        public string Color { get; set; }
    }
}