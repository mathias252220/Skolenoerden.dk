using LogicLibrary.Models.Terraformer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public string Get(string gameCode)
    {
        string jsonString = System.IO.File.ReadAllText(wwwrootPath + "/TerraformerSaveData/gameCodes.json");
        GameCodeListModel gameCodeList = JsonConvert.DeserializeObject<GameCodeListModel>(jsonString);

        string returnString;

        if (gameCodeList.gameCodes.Contains(gameCode))
        {
            returnString = System.IO.File.ReadAllText(wwwrootPath + "/TerraformerSaveData/" + gameCode + ".json");
        }
        else
        {
            return "NoGameFound";
        }

        return returnString;
    }

    // POST api/Terraformer
    [HttpPost]
    [Consumes("application/json")]
    public string Post([FromBody] JsonElement gameSaveRaw)
    {
        var gameSaveJson = gameSaveRaw.GetRawText();

        GameSaveModel gameSave = JsonConvert.DeserializeObject<GameSaveModel>(gameSaveJson);

        if (gameSave == null)
        {
            return "GameSaveNotRecognized";
        }
        else if (gameSave.gameCode == null)
        {
            return "NoGameCodeProvided";
        }
        else if (gameSave.gameMasterCode == null)
        {
            return "NoGameMasterCodeProvided";
        }
        else if (gameSave.teams == null)
        {
            return "NoTeamArrayProvided";
        }

        string jsonString = System.IO.File.ReadAllText(wwwrootPath + "/TerraformerSaveData/gameCodes.json");
        GameCodeListModel gameCodeList = JsonConvert.DeserializeObject<GameCodeListModel>(jsonString);

        if (!gameCodeList.gameCodes.Contains(gameSave.gameCode))
        {
            gameSave.newGame = false;
            gameCodeList.gameCodes.Add(gameSave.gameCode);
            string updatedGameCodesJson = JsonConvert.SerializeObject(gameCodeList, Formatting.Indented);
            System.IO.File.WriteAllText(wwwrootPath + "/TerraformerSaveData/gameCodes.json", updatedGameCodesJson);
            System.IO.File.WriteAllText(wwwrootPath + "/TerraformerSaveData/" + gameSave.gameCode + ".json", gameSaveJson);
            return "GameCreated";
        }
        else
        {
            if (gameSave.newGame == true)
            {
                return "GameCodeAlreadyExists";
            }
            else
            {
                string oldGameSaveJson = System.IO.File.ReadAllText(wwwrootPath + "/TerraformerSaveData/" + gameSave.gameCode + ".json");
                GameSaveModel oldGameSave = JsonConvert.DeserializeObject<GameSaveModel>(oldGameSaveJson);

                if (gameSave.gameMasterCode == oldGameSave.gameMasterCode && gameSave.newGame == false)
                {
                    string newGameSaveJson = JsonConvert.SerializeObject(gameSave, Formatting.Indented);
                    System.IO.File.WriteAllText(wwwrootPath + "/TerraformerSaveData/" + gameSave.gameCode + ".json", gameSaveJson);
                    return "GameSaved";
                }
                else
                {
                    return "WrongGameMasterCode";
                }
            }

        }
    }
}
