using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Dtos
{
    public class CreateErrorDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int EventsCount { get; set; }
        [Required]
        public string Level { get; set; }
    }
}
