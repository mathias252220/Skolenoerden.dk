using LogicLibrary.Models;

namespace LogicLibrary.TreasureHunt
{
    public interface ILogic
    {
		KeyPageModel CreateKeyPage();
		TaskModel CreateTask(char letter, KeyPageModel keyPage);
		OutpostModel CreateOutpost(string outpostName, KeyPageModel keyPage);
	}
}