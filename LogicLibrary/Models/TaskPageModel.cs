using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Models;
public class TaskPageModel
{
    public TaskModel[] TaskGroupOne { get; set; } = new TaskModel[3];
    public TaskModel[] TaskGroupTwo { get; set; } = new TaskModel[3];
    public TaskModel[] TaskGroupThree { get; set; } = new TaskModel[3];
    public TaskModel[] TaskGroupFour { get; set; } = new TaskModel[3];
    public TaskModel[] TaskGroupFive { get; set; } = new TaskModel[3];
    public TaskModel[] TaskGroupSix { get; set; } = new TaskModel[3];
    public TaskModel[] TaskGroupSeven { get; set; } = new TaskModel[3];
    public TaskModel[] TaskGroupEight { get; set; } = new TaskModel[3];
}
