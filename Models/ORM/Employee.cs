using System.ComponentModel.DataAnnotations;

namespace ders3.Models.ORM
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez!")]
        public string LastName { get; set; }
        public string? Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public string? City { get; set; }
        public DateTime? AddDate { get; set; }
    }
}
