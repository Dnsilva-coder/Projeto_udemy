using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.Dtos
{
    public class CategoryDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
