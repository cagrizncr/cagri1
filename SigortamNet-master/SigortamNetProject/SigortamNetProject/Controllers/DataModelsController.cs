using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SigortamNetProject.Context;
using SigortamNetProject.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using System.Threading.Tasks;

namespace SigortamNetProject.Controllers
{
    public class DataModelsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DataModels
        public ActionResult Index()
        {
            return View(db.Datas.ToList());
        }

        // GET: DataModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataModel dataModel = db.Datas.Find(id);
            if (dataModel == null)
            {
                return HttpNotFound();
            }
            return View(dataModel);
        }

        // GET: DataModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Plaka,Tckn,RuhsatKodu,RuhsatNo")] DataModel dataModel)
        {
            if (ModelState.IsValid)
            {
                db.Datas.Add(dataModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dataModel);
        }

        // GET: DataModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataModel dataModel = db.Datas.Find(id);
            if (dataModel == null)
            {
                return HttpNotFound();
            }
            return View(dataModel);
        }

        // POST: DataModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Plaka,Tckn,RuhsatKodu,RuhsatNo")] DataModel dataModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dataModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dataModel);
        }

        // GET: DataModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataModel dataModel = db.Datas.Find(id);
            if (dataModel == null)
            {
                return HttpNotFound();
            }
            return View(dataModel);
        }

        // POST: DataModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DataModel dataModel = db.Datas.Find(id);
            db.Datas.Remove(dataModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public async Task<ActionResult> GetOffer( int id)
        {
            var data= db.Datas.FirstOrDefault(x => x.Id == id);
            if (data == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var client = new HttpClient())
            {
                //set up client
                client.BaseAddress = new Uri(string.Format("{0}://{1}",Request.Url.Scheme, Request.Url.Authority));
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestUri = new Uri("http://localhost:58402/api/offers/getoffer");
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var serializedData=serializer.Serialize(data);
                var content = serializedData.ToString();
                var response = await client.PostAsJsonAsync(requestUri.AbsoluteUri, content);
                var result = await response.Content.ReadAsStringAsync();

                var obj=serializer.Deserialize(result,typeof(ListOfferResponseModel));

                foreach (var item in (obj as ListOfferResponseModel).Offers)
                {
                    var offer=new OfferModel
                    {
                        CompanyLogo=item.CompanyLogo,
                        CompanyName=item.CompanyName,
                        TcNo=data.Tckn,
                        OfferDescription=item.OfferDescription,
                        OfferPrice=item.OfferAmount
                    };

                    db.Offers.Add(offer); 
                }

                db.SaveChanges();

                TempData["listOfferModel"] = obj;
                return RedirectToAction("ListOffers", "offer");
            }
        }
    }
}
