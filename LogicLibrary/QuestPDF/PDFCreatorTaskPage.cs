using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;
using LogicLibrary.Models;
using LogicLibrary.Enums;

namespace LogicLibrary.QuestPDF;
public class PDFCreatorTaskPage
{
    private static float titleTextSize { get; set; } = 38f;

    private static float subtitleTextSize { get; set; } = 18f;

    private static float paddingUnderTitle {  get; set; } = 40f;

    private static float regularTextSize { get; set; } = 14f;

    private static float rowSize { get; set; } = 180f;

    private static float underscoreTextSize { get; set; } = 38f;

    private static float paddingSides { get; set; } = 50f;

    private static float paddingMiddle { get; set; } = 25f;

    private static float paddingAround { get; set; } = 25f;

    private static float lineHeight { get; set; } = 1.5f;

    public IDocument CreateTaskPage(List<TaskGroupModel> taskPage)
    {
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);

                page.DefaultTextStyle(x => x.FontSize(regularTextSize));

                page.Header().AlignCenter().PaddingBottom(paddingUnderTitle).Text("Skolenørdens Opgaver").SemiBold().FontSize(titleTextSize);

                page.Content().Table(table =>
                {

                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    for (int i = 0; i < 10; i++)
                    {
                        if (i % 2 == 0)
                        {
                            table.Cell().Row((uint)i / 2 + 1).Column(1).ColumnSpan(3).Border(1).PaddingLeft(paddingAround).PaddingRight(paddingAround).PaddingBottom(paddingAround).Table(CreateTaskGroup(taskPage[i].Tasks, i));
                        }
                        else
                        {
                            table.Cell().Row((uint)i / 2 + 1).Column(4).ColumnSpan(3).Border(1).PaddingLeft(paddingAround).PaddingRight(paddingAround).PaddingBottom(paddingAround).Table(CreateTaskGroup(taskPage[i].Tasks, i));
                        }
                    }
                });
            });
        });

        return document;
    }

    private static Action<TableDescriptor> CreateTaskGroup(List<TaskModel> tasks, int taskGroupNumber)
    {
        return taskGroup =>
        {
            taskGroup.ColumnsDefinition(columns =>
            {
                columns.RelativeColumn();
            });

            taskGroup.Cell().Row((uint)1).AlignCenter().Text(ChooseTaskName(tasks[0].TaskType)).FontSize(subtitleTextSize);

            for (int i = 0; i < 3; i++)
            {
                taskGroup.Cell().Row((uint)i + 2).Column(1).AlignLeft().Text($"{i + taskGroupNumber * 3 + 1}) {tasks[i].Question}").LineHeight(lineHeight);

                if (tasks[i].TaskType == Enums.TaskTypeEnum.Equation)
                {
                    taskGroup.Cell().Row((uint)i + 2).Column(1).AlignRight().Text("x =_______").LineHeight(lineHeight);
                }
                else
                {
                    taskGroup.Cell().Row((uint)i + 2).Column(1).AlignRight().Text("__________").LineHeight(lineHeight);
                }
            }
        };
    }

    private static string ChooseTaskName(TaskTypeEnum taskType)
    {
        if (taskType == TaskTypeEnum.Addition)
        {
            return "Plus";
        }
        else if (taskType == TaskTypeEnum.Subtraction)
        {
            return "Minus";
        }
        else if (taskType == TaskTypeEnum.Multiplication)
        {
            return "Gange";
        }
        else if (taskType == TaskTypeEnum.Division)
        {
            return "Division";
        }
        else if (taskType == TaskTypeEnum.Fraction)
        {
            return "Brøker";
        }
        else if (taskType == TaskTypeEnum.Equation)
        {
            return "Ligninger";
        }

        throw new Exception("Error occured: Task type not recognized");
    }
}
