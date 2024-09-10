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
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using LogicLibrary.Models;

namespace LogicLibrary.QuestPDF;
public class PDFCreatorTaskPage
{
    public IDocument CreateTaskPage(List<List<TaskModel>> tasks)
    {

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);

                page.DefaultTextStyle(x => x.FontSize(14));

                page.Content().Column(column =>
                {
                    for (int i = 0; i <= 4; i++)
                    {
                        column.Item().Height(210).Table(CreateRow(tasks[i]));
                    }
                });
            });
        });

        return document;
    }

    private static Action<TableDescriptor> CreateRow(List<TaskModel> tasks)
    {
        return taskRow =>
        {
            taskRow.ColumnsDefinition(columns =>
            {
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
            });

            if (tasks[1].TaskType == Enums.TaskTypeEnum.Equation)
            {
                for (int i = 0; i < 3; i++)
                {
                    taskRow.Cell().Row((uint)i + 1).Column(1).ColumnSpan(5).AlignLeft().Text($"{i + 1}) {tasks[i].Question}");
                    taskRow.Cell().Row((uint)i + 1).Column(1).ColumnSpan(5).AlignRight().Text("__________");
                };
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    taskRow.Cell().Row((uint)i + 1).Column(1).ColumnSpan(2).AlignLeft().Text($"{i + 1}) {tasks[i].Question}");
                    taskRow.Cell().Row((uint)i + 1).Column(1).ColumnSpan(2).AlignRight().Text("__________");
                }
                for (int i = 3; i < 6; i++)
                {
                    taskRow.Cell().Row((uint)i + 1).Column(4).ColumnSpan(2).AlignLeft().Text($"{i + 1}) {tasks[i].Question}");
                    taskRow.Cell().Row((uint)i + 1).Column(4).ColumnSpan(2).AlignRight().Text("__________");
                }
            }
        };
    }
}
