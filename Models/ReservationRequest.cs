using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaTrainApp.Models
{
    public class ReservationRequest
    {
        public Train Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
