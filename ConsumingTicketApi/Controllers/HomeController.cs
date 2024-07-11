using ConsumingTicketApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsumingTicketApi.Controllers
{
    public class HomeController : Controller
    {
        /*
         [HttpGet]
        public IEnumerable<Reservation> Get() => _ticReservation.Reservations;
         */
        public async Task<IActionResult> Index()
        {
            List<Reservation> reservations = new List<Reservation>();

            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:6000/ticket/myapi"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservations = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
                }
            }

            return View(reservations);
        }

        /*
         [HttpGet("{id}")]
        public ActionResult<Reservation> Get(int id) { 
            if(id == 0)
            {
                return BadRequest("Value must be greater than 0....");
            }
            return Ok(_ticReservation[id]);
        }*/


        public IActionResult AddReservation() => View();

        [HttpPost]
        public async Task<ActionResult> AddReservation(Reservation reservation)
        {
           // var treservation = new Reservation();
            var httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(reservation), 
                Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://localhost:6000/ticket/myapi", content);

            var responseMessage = await response.Content.ReadAsStringAsync();
           // treservation = JsonConvert.DeserializeObject<Reservation>(responseMessage);

            return RedirectToAction("Index");

        }


    }
}
