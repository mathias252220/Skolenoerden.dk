using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary.Models;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using static System.Net.Mime.MediaTypeNames;
using Fractions;

namespace LogicLibrary.QuestPDF;

public class PDFCreatorFracEq : IPDFCreator
{
    public string taskTypes { get; set; } = "FractionEquation";

    private static int titleTextSize { get; set; } = 38;

    private static int subtitleTextSize { get; set; } = 12;

    private static int regularTextSize { get; set; } = 14;

    private static int underscoreTextSize { get; set; } = 38;

    private static int snippingTextSize { get; set; } = 12;

    public IDocument PrintFullPDF(KeyPageModel keyPage, List<OutpostModel> outposts, List<GroupModel> groups)
    {
        var keyPagePDF = CreateKeyPagePDF(keyPage, groups);
        var outpostsPDF = CreateOutpostPagesPDF(outposts, groups);

        return Document.Merge(keyPagePDF, outpostsPDF);
    }
    public IDocument CreateKeyPagePDF(KeyPageModel keyPage, List<GroupModel> groups)
    {
        var document = Document.Create(container =>
        {
            foreach (GroupModel group in groups)
            {
                container.Page(CreateKeyPage(keyPage, group));
            }
        });
        return document;
    }
    public IDocument CreateOutpostPagesPDF(List<OutpostModel> outposts, List<GroupModel> groups)
    {
        var document = Document.Create(container =>
        {
            OutpostModel tempOutpost = new();

            for (int i = 0; i < outposts.Count - 1; i++)
            {
                int generationNumber = 0;

                for (int j = 0; j < Math.Ceiling(groups.Count / 2.0); j++)
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);

                        page.DefaultTextStyle(x => x.FontSize(regularTextSize));

                        page.Content().Column(c =>
                        {
                            if (generationNumber > outposts.Count - 3)
                            {
                                generationNumber = 0;
                            }

                            c.Item().Height(421).Table(CreatePageOne(outposts[0], outposts[generationNumber + 1], j * 2 + 1));
                            generationNumber++;

                            if (generationNumber > outposts.Count - 3)
                            {
                                generationNumber = 0;
                            }

                            if (j * 2 < groups.Count - 1)
                            {
                                c.Item().Height(421).Table(CreatePageTwo(outposts[0], outposts[generationNumber + 1], j * 2 + 2));
                                generationNumber++;
                            }
                        });
                    });
                }

                //Mix the order of outposts after each generation
                tempOutpost = outposts[0];
                outposts.RemoveAt(0);
                outposts.Insert(outposts.Count - 1, tempOutpost);
            }
        });
        return document;
    }
    private static Action<PageDescriptor> CreateKeyPage(KeyPageModel keyPage, GroupModel group)
    {
        return page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(2, Unit.Centimetre);
            page.DefaultTextStyle(x => x.FontSize(regularTextSize));

            page.Header()
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn();
                });
                table.Cell().Row(1).AlignCenter().Text("Nøgle").SemiBold().FontSize(titleTextSize);
                table.Cell().Row(2).AlignCenter().Text($"Gruppe {group.groupNumber}").FontSize(subtitleTextSize);
            });

            page.Content()
            .PaddingVertical(1, Unit.Centimetre)
            .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(1);
                    columns.RelativeColumn(1);
                    columns.RelativeColumn(1);
                });

                for (int i = 0; i < Math.Ceiling(keyPage.LetterKeys.Count / 3.0); i++)
                {
                    table.Cell().Row((uint)i * 2 + 1).Text(string.Empty);

                    for (int j = 0; j < 3; j++)
                    {
                        table.Cell().Row((uint)i * 2 + 2).Column((uint)j + 1).AlignCenter().Text($"{keyPage.LetterKeys[i * 3 + j].KeyLetter} = {Fraction.FromDoubleRounded(keyPage.LetterKeys[i * 3 + j].KeyNumber)}");
                    }
                }
            });
        };
    }
    private static Action<TableDescriptor> CreatePageOne(OutpostModel currentOutpost, OutpostModel nextOutpost, int groupNumber)
    {
        return pageOne =>
        {
            pageOne.ColumnsDefinition(columns =>
            {
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
            });

            pageOne.Header(header =>
            {
                header.Cell().Row(1).ColumnSpan(5).AlignCenter().Text(currentOutpost.Name).SemiBold().FontSize(titleTextSize);
                header.Cell().Row(2).ColumnSpan(5).AlignCenter().PaddingBottom(20).Text($"Gruppe {groupNumber}").FontSize(subtitleTextSize);
            });

            int rightHalf = nextOutpost.Tasks.Count / 2;
            int leftHalf = nextOutpost.Tasks.Count - rightHalf;

            for (int j = 0; j < leftHalf; j++)
            {
                pageOne.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignLeft().PaddingLeft(75).PaddingVertical(5).Text($"{j + 1}) {nextOutpost.Tasks[j].Question}");
                if (nextOutpost.Tasks[j].TaskType == Enums.TaskTypeEnum.Equation)
                {
                    pageOne.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("x =_______");

                }
                else
                {
                    pageOne.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("__________");

                }
            }
            for (int j = 0; j < rightHalf; j++)
            {
                pageOne.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignLeft().PaddingLeft(75).PaddingVertical(5).Text($"{leftHalf + j + 1}) {nextOutpost.Tasks[leftHalf + j].Question}");
                if (nextOutpost.Tasks[leftHalf + j].TaskType == Enums.TaskTypeEnum.Equation)
                {
                    pageOne.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("x =_______");
                }
                else
                {
                    pageOne.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("__________");

                }
            }
            for (int j = 0; j < (8 - leftHalf); j++)
            {
                pageOne.Cell().Row((uint)leftHalf + (uint)j).PaddingVertical(5).Text(" ");
            }

            pageOne.Footer(footer =>
            {
                footer.Cell().Row(1).ColumnSpan(5).AlignCenter().Text(nextOutpost.ReturnNameUnderscored()).FontSize(underscoreTextSize);

                var scissorImage = File.ReadAllBytes("wwwroot/Images/ScissorIcon.png");
                footer.Cell().Row(2).Column(1).AlignLeft().PaddingLeft(10).Height(5, Unit.Millimetre).Image(scissorImage).FitHeight();
                footer.Cell().Row(2).ColumnSpan(5).AlignCenter()
                .Text("--------------------------------------------------------------------------------------------------------------------------------")
                .FontSize(snippingTextSize);
            }
            );
        };
    }
    private static Action<TableDescriptor> CreatePageTwo(OutpostModel currentOutpost, OutpostModel nextOutpost, int groupNumber)
    {
        return pageTwo =>
        {
            pageTwo.ColumnsDefinition(columns =>
            {
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
            });

            pageTwo.Header(header =>
            {
                header.Cell().Row(1).ColumnSpan(5).AlignCenter().Text(currentOutpost.Name).SemiBold().FontSize(titleTextSize);
                header.Cell().Row(2).ColumnSpan(5).AlignCenter().PaddingBottom(20).Text($"Gruppe {groupNumber}").FontSize(subtitleTextSize);
            });

            int rightHalf = nextOutpost.Tasks.Count / 2;
            int leftHalf = nextOutpost.Tasks.Count - rightHalf;

            for (int j = 0; j < leftHalf; j++)
            {
                pageTwo.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignLeft().PaddingLeft(75).PaddingVertical(5, Unit.Point).Text($"{j + 1}) {nextOutpost.Tasks[j].Question}");
                if (nextOutpost.Tasks[j].TaskType == Enums.TaskTypeEnum.Equation)
                {
                    pageTwo.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("x =_______");
                }
                else
                {
                    pageTwo.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("__________");
                }
            }
            for (int j = 0; j < rightHalf; j++)
            {
                pageTwo.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignLeft().PaddingLeft(75).PaddingVertical(5, Unit.Point).Text($"{leftHalf + j + 1}) {nextOutpost.Tasks[leftHalf + j].Question}");
                if (nextOutpost.Tasks[leftHalf + j].TaskType == Enums.TaskTypeEnum.Equation)
                {
                    pageTwo.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("x =_______");
                }
                else
                {
                    pageTwo.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("__________");
                }
            }
            for (int j = 0; j < (8 - leftHalf); j++)
            {
                pageTwo.Cell().Row((uint)leftHalf + (uint)j).PaddingVertical(5).Text(" ");
            }

            pageTwo.Footer(footer =>
            {
                footer.Cell().ColumnSpan(5).AlignCenter().Text(nextOutpost.ReturnNameUnderscored()).FontSize(underscoreTextSize);

            });
        };
    }

}
