using SigortamNetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfferApi.Services
{
    public class BCompanyService
    {
        public OfferResponseModel TeklifHesaplama(DataModel userDefinition)
        {
            // tekif hesabı 
            OfferResponseModel response = new OfferResponseModel();

            response.CompanyName = "B";
            response.CompanyLogo = "B";
            response.NumberPlate = "23165";
            response.OfferAmount = new Random().Next(1, 250);
            response.OfferDescription = "kasko";
            return response;
        }


    }
}