using LogicLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Models;

public class TaskModel
{
    public double Answer { get; set; }
    public double VariableOne { get; set; } = 0;
    public double VariableTwo { get; set; } = 0;
    public double VariableThree { get; set; } = 0;
    public double VariableFour { get; set; } = 0;
    public string Question { get; set; }
    public TaskTypeEnum TaskType { get; set; }
}
