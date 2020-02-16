using SigortamNetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfferApi.Services
{
    public class CCompanyService
    {
        public OfferResponseModel TeklifHesaplama(DataModel userDefinition)
        {
            // tekif hesabı 
            OfferResponseModel response = new OfferResponseModel();

            response.CompanyName = "C";
            response.CompanyLogo = "C";
            response.NumberPlate = "23168";
            response.OfferAmount = new Random().Next(1, 250);
            response.OfferDescription = "kasko";
            return response;
        }
    }
}