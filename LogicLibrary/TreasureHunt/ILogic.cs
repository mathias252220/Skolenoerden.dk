using LogicLibrary.Models;
using LogicLibrary.Enums;

namespace LogicLibrary.TreasureHunt
{
    public interface ILogic
    {
        public string grade { get; set; }
        KeyPageModel CreateKeyPage();
		TaskModel CreateTask(char letter, KeyPageModel keyPage);
		OutpostModel CreateOutpost(string outpostName, KeyPageModel keyPage);
	}
}