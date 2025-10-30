using LogicLibrary.Models.Terraformer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkattejagtGeneratorWebApp.Components.API.Controllers;
[Route("api/Terraformer")]
[ApiController]
public class TerraformerController : ControllerBase
{
    string wwwrootPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

    // GET: api/Terraformer
    [HttpGet]
    public string Get(string gameNameInput)
    {
        string jsonString = System.IO.File.ReadAllText(wwwrootPath + "/TerraformerSaveData/gameNames.json");
        GameNameListModel gameNameList = JsonConvert.DeserializeObject<GameNameListModel>(jsonString);

        string returnString;
        string gameName = gameNameList.GameNames.FirstOrDefault(name => name == gameNameInput).ToString();

        if (gameName == null)
        {
            returnString = "No game found";
        }
        else
        {
            returnString = System.IO.File.ReadAllText(wwwrootPath + "/TerraformerSaveData/" + gameName + ".json");
        }

            return returnString;
    }

    // POST api/Terraformer
    [HttpPost]
    public string Post([FromBody] string gameName, string gameSave, string gameMasterCode)
    {
        string gameString = gameSave;

        if (gameSave == "newGame")
        {
            string jsonString = System.IO.File.ReadAllText(wwwrootPath + "/TerraformerSaveData/gameNames.json");

            GameNameListModel gameNameList = JsonConvert.DeserializeObject<GameNameListModel>(jsonString);

            if (gameNameList.GameNames.FirstOrDefault(name => name == gameName) == null)
            {
                GameSaveModel newGame = new GameSaveModel
                {
                    gameCode = gameName,
                    gameMasterCode = gameMasterCode,
                    teams = new List<TeamModel>()
                };

                gameString = JsonConvert.SerializeObject(newGame);
            }
        }

        System.IO.File.WriteAllText(wwwrootPath + "/TerraformerSaveData/" + gameName + ".json", gameString);

        return gameString;
    }
}
