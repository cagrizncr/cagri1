using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigortamNetProject.Models
{
    public class ListOfferResponseModel
    {

        public ListOfferResponseModel()
        {
            Offers = new List<OfferResponseModel>();
        }
        public List<OfferResponseModel> Offers { get; set; }
    }
}