﻿using LogicLibrary.Models;
using LogicLibrary.Enums;

namespace LogicLibrary.TreasureHunt
{
    public interface ILogic
    {
        public GradeEnum grade { get; set; }
        KeyPageModel CreateKeyPage();
		TaskModel CreateTask(char letter, KeyPageModel keyPage);
		OutpostModel CreateOutpost(string outpostName, KeyPageModel keyPage);
	}
}