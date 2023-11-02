using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogSitesi.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        [Display(Name = "Adı"), StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Soyadı"), StringLength(50)]
        public string SurName { get; set; }


        [StringLength(50), EmailAddress]
        public string? Email { get; set; }



        [Display(Name = "Mesaj"), StringLength(500)]
        public string Message { get; set; }


        [Display(Name = "Telefon"), StringLength(20)]
        public string? Phone { get; set; }


        [Display(Name = "Eklenme Tarihi")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
