using LogicLibrary.Models;

namespace LogicLibrary.TaskGenerator;
public interface ITaskGenerator
{
    TaskModel CreateTaskZero();
    TaskModel CreateTaskZero(double taskAnswer);
    TaskModel CreateTaskOne();
    TaskModel CreateTaskOne(double taskAnswer);
    TaskModel CreateTaskTwo();
    TaskModel CreateTaskTwo(double taskAnswer);
    TaskModel CreateTaskThree();
    TaskModel CreateTaskThree(double taskAnswer);
    TaskModel CreateTaskFour();
    TaskModel CreateTaskFour(double taskAnswer);
    TaskModel CreateTaskFive();
    TaskModel CreateTaskFive(double taskAnswer);
    TaskModel CreateTaskSix();
    TaskModel CreateTaskSix(double taskAnswer);
    TaskModel CreateTaskSeven();
    TaskModel CreateTaskSeven(double taskAnswer);
    TaskModel CreateTaskEight();
    TaskModel CreateTaskEight(double taskAnswer);
    TaskModel CreateTaskNine();
    TaskModel CreateTaskNine(double taskAnswer);


}