using SigortamNetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfferApi.Services
{
    public class ACompanyService
    {
      public OfferResponseModel TeklifHesaplama(DataModel userDefinition)
        {
            // tekif hesabı 
            OfferResponseModel response =new OfferResponseModel();

            response.CompanyName = "A";
            response.CompanyLogo = "A";
            response.NumberPlate = "3215";
            response.OfferAmount = 54;
            response.OfferDescription = "kasko";
            return response;
        }

    }
}