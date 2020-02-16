using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SigortamNetProject.Models
{
    [Table("Offer")]
    public class OfferModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Firma adı zorunludur.")]
        public string CompanyName { get; set; }
        [Display(Name ="Logo")]
        public string CompanyLogo { get; set; }
        [Required(ErrorMessage = "Teklif açıklaması zorunludur."), Display(Name = "Teklif Açıklaması")]
        public string OfferDescription { get; set; }
        [Required(ErrorMessage = "Teklif tutarı zorunludur."), Display(Name = "Teklif Tutarı")]
        public decimal OfferPrice { get; set; }

        public string TcNo { get; set; }
    }
}