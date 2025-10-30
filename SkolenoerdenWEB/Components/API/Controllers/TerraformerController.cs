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
        string gameName = gameNameList.gameNames.FirstOrDefault(name => name == gameNameInput).ToString();

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
    public string Post([FromBody] string gameSaveString)
    {
        string returnString;

        GameSaveModel gameSave = JsonConvert.DeserializeObject<GameSaveModel>(gameSaveString);

        string jsonString = System.IO.File.ReadAllText(wwwrootPath + "/TerraformerSaveData/gameNames.json");
        GameNameListModel gameNameList = JsonConvert.DeserializeObject<GameNameListModel>(jsonString);

        if (!gameNameList.gameNames.Contains(gameSave.gameCode))
        {
            gameNameList.gameNames.Add(gameSave.gameCode);
            string updatedGameNamesJson = JsonConvert.SerializeObject(gameNameList, Formatting.Indented);
            System.IO.File.WriteAllText(wwwrootPath + "/TerraformerSaveData/gameNames.json", updatedGameNamesJson);
            returnString = "GameCreated";
        }
        else
        {
            string oldGameSaveJson = System.IO.File.ReadAllText(wwwrootPath + "/TerraformerSaveData/" + gameSave.gameCode + ".json");
            GameSaveModel oldGameSave = JsonConvert.DeserializeObject<GameSaveModel>(oldGameSaveJson);

            if (gameSave.gameMasterCode == oldGameSave.gameMasterCode)
            {
                string newGameSaveJson = JsonConvert.SerializeObject(gameSave, Formatting.Indented);
                System.IO.File.WriteAllText(wwwrootPath + "/TerraformerSaveData/" + gameSave.gameCode + ".json", newGameSaveJson);
                returnString = "GameSaved";
            }
            else
            {
                returnString = "WrongGameMasterCodeOrGameExists";
            }

        }

        return returnString;

    }
}
