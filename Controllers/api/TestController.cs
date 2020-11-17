using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YoYoTestDemo.Models;
using YoYoTestDemo.Services;
using YoYoTestDemo.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YoYoTestDemo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private IPlayerService _playerService;

        public TestController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        
        [HttpGet("GetPlayers")]
        public ActionResult GetPlayers()
        {
            return Ok(_playerService.GetPlayers());
        }

        [HttpGet("FitnessRating")]
        public ActionResult GetFitnessRating()
        {
            var fitnessRatingData = new List<FitnessRating>();
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"json\\fitnessrating_beeptest.json"}");
            var jsonText = System.IO.File.ReadAllText(folderDetails);

            JArray jsonArray = JArray.Parse(jsonText);
            foreach (var item in jsonArray)
            {
                var jsonObj = JsonConvert.DeserializeObject<FitnessRating>(item.ToString());
                fitnessRatingData.Add(jsonObj);
            }

            return Ok(fitnessRatingData);
        }


        [HttpGet("WarnPlayer/{id}")]
        public ActionResult WarnPlayer(int id)
        {
            var allPlayers = _playerService.GetPlayers();
            try
            {
                int editIndex = allPlayers.FindIndex(o => o.id == id);
                allPlayers[editIndex].warn = true;
                return Ok(allPlayers[editIndex]);
            }
            catch (Exception)
            {
                return NotFound();
            }
           
        }

        [HttpPost("ResultPlayer/{id}")]
        public ActionResult ResultPlayer([FromForm]PlayerResultViewModel playerResultRecieved)
        {
            var playerResult = _playerService.resultPlayer(playerResultRecieved.id, playerResultRecieved.result);
            Console.WriteLine(playerResultRecieved.id + " : " + playerResultRecieved.result);

            return Ok(playerResult);
        }

        
    }
}
