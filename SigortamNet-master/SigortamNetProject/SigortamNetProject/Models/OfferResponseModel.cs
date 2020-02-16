using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigortamNetProject.Models
{
    public class OfferResponseModel
    {
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string OfferDescription { get; set; }
        public decimal OfferAmount { get; set; }
        public string NumberPlate { get; set; }
    } 
}