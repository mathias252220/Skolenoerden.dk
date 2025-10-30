using LogicLibrary.Models.Terraformer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;

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

        System.IO.File.WriteAllText(wwwrootPath + "/TerraformerSaveData/lastAccessedGame2.txt", gameNameInput);

        return returnString;
    }

    // POST api/Terraformer
    [HttpPost]
    [Consumes("application/json")]
    public string Post([FromBody] JsonElement gameSaveRaw)
    {
        var gameSaveJson = gameSaveRaw.GetRawText();
        GameSaveModel gameSave = JsonConvert.DeserializeObject<GameSaveModel>(gameSaveJson);

        string returnString;

        string jsonString = System.IO.File.ReadAllText(wwwrootPath + "/TerraformerSaveData/gameNames.json");
        GameNameListModel gameNameList = JsonConvert.DeserializeObject<GameNameListModel>(jsonString);

        if (!gameNameList.gameNames.Contains(gameSave.gameCode))
        {
            gameNameList.gameNames.Add(gameSave.gameCode);
            string updatedGameNamesJson = JsonConvert.SerializeObject(gameNameList, Formatting.Indented);
            System.IO.File.WriteAllText(wwwrootPath + "/TerraformerSaveData/gameNames.json", updatedGameNamesJson);
            System.IO.File.WriteAllText(wwwrootPath + "/TerraformerSaveData/" + gameSave.gameCode + ".json", gameSaveJson);
            returnString = "GameCreated";
        }
        else
        {
            string oldGameSaveJson = System.IO.File.ReadAllText(wwwrootPath + "/TerraformerSaveData/" + gameSave.gameCode + ".json");
            GameSaveModel oldGameSave = JsonConvert.DeserializeObject<GameSaveModel>(oldGameSaveJson);

            if (gameSave.gameMasterCode == oldGameSave.gameMasterCode)
            {
                string newGameSaveJson = JsonConvert.SerializeObject(gameSave, Formatting.Indented);
                System.IO.File.WriteAllText(wwwrootPath + "/TerraformerSaveData/" + gameSave.gameCode + ".json", gameSaveJson);
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
