using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SigortamNetProject.Context;
using SigortamNetProject.Models;

namespace SigortamNetProject.Controllers
{
    public class OfferController : Controller
    {
        private DatabaseContext db = new DatabaseContext();


        public ActionResult ListOffers()
        {
            var offerList=(ListOfferResponseModel)TempData["listOfferModel"];
            if (offerList==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            


            return View(offerList);
        }
        public ActionResult ListOldOffers(int id)
        {
            var data = db.Datas.FirstOrDefault(x=>x.Id==id);

            if(data==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var offerList = db.Offers.Where(x => x.TcNo == data.Tckn).ToList();
            if (offerList == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);



            return View(offerList);
        }

    }
}
