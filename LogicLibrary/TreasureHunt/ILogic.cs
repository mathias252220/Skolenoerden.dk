using LogicLibrary.Models;

namespace LogicLibrary.TreasureHunt
{
    public interface ILogic
    {
        public string grade { get; set; }
        KeyPageModel CreateKeyPage();
		OutpostModel CreateOutpost(string outpostName, KeyPageModel keyPage);
		TaskModel CreateTask(char letter, KeyPageModel keyPage);
	}
}