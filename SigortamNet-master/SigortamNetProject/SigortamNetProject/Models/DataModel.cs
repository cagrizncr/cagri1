using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SigortamNetProject.Models
{
    [Table("Data")]
    public class DataModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Plaka zorunludur.")]
        public string Plaka { get; set; }
        [Required(ErrorMessage = "Tc No zorunludur."),Display(Name ="Tc No"),MaxLength(length:11),MinLength(length:11)]
        public string Tckn { get; set; }
        [Required(ErrorMessage = "Ruhsat kodu zorunludur."), Display(Name = "Ruhsat Kodu")]
        public string RuhsatKodu { get; set; }
        [Required(ErrorMessage = "Ruhsat numarası zorunludur."), Display(Name = "Ruhsat No")]
        public string RuhsatNo { get; set; }
    }
}