using Newtonsoft.Json;
using SigortamNetProject.Models;
using System.Web.Http;
using System.Web.Http.Cors;
using OfferApi.Services;
using System.Collections.Generic;

namespace OfferApi.Controllers
{
    public class OffersController : ApiController
    {

        public OffersController()
        {

            List<ListOfferResponseModel> Offers = new List<ListOfferResponseModel>();
        }
        [EnableCors(origins: "http://localhost:58402/api/offers", headers: "*", methods: "*")]

        [HttpPost]
        public IHttpActionResult GetOffer(DataModel userDefinition)
        {
            OfferResponseModel responseA = new OfferResponseModel();
            Services.ACompanyService Aservices = new Services.ACompanyService();
            responseA = Aservices.TeklifHesaplama(userDefinition);
            ListOfferResponseModel offerList = new ListOfferResponseModel();
            offerList.Offers.Add(responseA);


            OfferResponseModel responseB = new OfferResponseModel();
            Services.BCompanyService Bservices = new Services.BCompanyService();
            responseB = Bservices.TeklifHesaplama(userDefinition);
            offerList.Offers.Add(responseB);

            OfferResponseModel responseC = new OfferResponseModel();
            Services.CCompanyService Cservices = new Services.CCompanyService();
            responseC = Cservices.TeklifHesaplama(userDefinition);
            offerList.Offers.Add(responseC);

            return Ok(offerList);
        }
    }
}
