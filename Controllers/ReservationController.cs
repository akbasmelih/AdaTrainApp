using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AdaTrainApp.Models;

namespace TrainReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        [HttpPost]
        public ActionResult<ReservationResponse> Post([FromBody] ReservationRequest request)
        {


            ReservationResponse response = new ReservationResponse();
            response.RezervasyonYapilabilir = false;
            response.YerlesimAyrinti = new List<YerlesimAyrinti>();

            foreach (var vagon in request.Tren.Vagonlar)
            {
                if (vagon.DoluKoltukAdet < vagon.Kapasite * 0.7)
                {
                    int availableSeats = (int)(vagon.Kapasite * 0.7) - vagon.DoluKoltukAdet;
                    int reservationCount = availableSeats < request.RezervasyonYapilacakKisiSayisi ? availableSeats : request.RezervasyonYapilacakKisiSayisi;
                    response.YerlesimAyrinti.Add(new YerlesimAyrinti { VagonAdi = vagon.Ad, KisiSayisi = reservationCount });
                    request.RezervasyonYapilacakKisiSayisi -= reservationCount;
                }

                if (request.RezervasyonYapilacakKisiSayisi == 0)
                {
                    response.RezervasyonYapilabilir = true;
                    break;
                }
            }

            return response;
        }
    }
}