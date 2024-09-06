using LogicLibrary.Models;

namespace LogicLibrary.TreasureHunt;

public interface ILogic
{
    public string grade { get; set; }
    public string taskTypes { get; set; }
    KeyPageModel CreateKeyPage();
	void PopulateOutpost(OutpostModel outpost, KeyPageModel keyPage);
	TaskModel CreateTask(char letter, KeyPageModel keyPage);
}