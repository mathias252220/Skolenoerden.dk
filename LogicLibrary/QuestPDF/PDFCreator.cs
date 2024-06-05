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

namespace LogicLibrary.QuestPDF
{
    public class PDFCreator
    {
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
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.DefaultTextStyle(x => x.FontSize(20));

                        page.Header()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                            });
                            table.Cell().Row(1).AlignCenter().Text("Nøgle").SemiBold().FontSize(48);
                            table.Cell().Row(2).AlignCenter().Text($"Gruppe {group.groupNumber}").FontSize(12);
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

                            table.Cell().Row(1).Text(string.Empty);
                            table.Cell().Row(2).Column(1).AlignCenter().Text(keyPage.LetterKeys[0].getString());
                            table.Cell().Row(2).Column(2).AlignCenter().Text(keyPage.LetterKeys[1].getString());
                            table.Cell().Row(2).Column(3).AlignCenter().Text(keyPage.LetterKeys[2].getString());
                            table.Cell().Row(3).Text(string.Empty);
                            table.Cell().Row(4).Column(1).AlignCenter().Text(keyPage.LetterKeys[3].getString());
                            table.Cell().Row(4).Column(2).AlignCenter().Text(keyPage.LetterKeys[4].getString());
                            table.Cell().Row(4).Column(3).AlignCenter().Text(keyPage.LetterKeys[5].getString());
                            table.Cell().Row(5).Text(string.Empty);
                            table.Cell().Row(6).Column(1).AlignCenter().Text(keyPage.LetterKeys[6].getString());
                            table.Cell().Row(6).Column(2).AlignCenter().Text(keyPage.LetterKeys[7].getString());
                            table.Cell().Row(6).Column(3).AlignCenter().Text(keyPage.LetterKeys[8].getString());
                            table.Cell().Row(7).Text(string.Empty);
                            table.Cell().Row(8).Column(1).AlignCenter().Text(keyPage.LetterKeys[9].getString());
                            table.Cell().Row(8).Column(2).AlignCenter().Text(keyPage.LetterKeys[10].getString());
                            table.Cell().Row(8).Column(3).AlignCenter().Text(keyPage.LetterKeys[11].getString());
                            table.Cell().Row(9).Text(string.Empty);
                            table.Cell().Row(10).Column(1).AlignCenter().Text(keyPage.LetterKeys[12].getString());
                            table.Cell().Row(10).Column(2).AlignCenter().Text(keyPage.LetterKeys[13].getString());
                            table.Cell().Row(10).Column(3).AlignCenter().Text(keyPage.LetterKeys[14].getString());
                            table.Cell().Row(11).Text(string.Empty);
                            table.Cell().Row(12).Column(1).AlignCenter().Text(keyPage.LetterKeys[15].getString());
                            table.Cell().Row(12).Column(2).AlignCenter().Text(keyPage.LetterKeys[16].getString());
                            table.Cell().Row(12).Column(3).AlignCenter().Text(keyPage.LetterKeys[17].getString());
                            table.Cell().Row(13).Text(string.Empty);
                            table.Cell().Row(14).Column(1).AlignCenter().Text(keyPage.LetterKeys[18].getString());
                            table.Cell().Row(14).Column(2).AlignCenter().Text(keyPage.LetterKeys[19].getString());
                            table.Cell().Row(14).Column(3).AlignCenter().Text(keyPage.LetterKeys[20].getString());
                            table.Cell().Row(15).Text(string.Empty);
                            table.Cell().Row(16).Column(1).AlignCenter().Text(keyPage.LetterKeys[21].getString());
                            table.Cell().Row(16).Column(2).AlignCenter().Text(keyPage.LetterKeys[22].getString());
                            table.Cell().Row(16).Column(3).AlignCenter().Text(keyPage.LetterKeys[23].getString());
                            table.Cell().Row(17).Text(string.Empty);
                            table.Cell().Row(18).Column(1).AlignCenter().Text(keyPage.LetterKeys[24].getString());
                            table.Cell().Row(18).Column(2).AlignCenter().Text(keyPage.LetterKeys[25].getString());
                            table.Cell().Row(18).Column(3).AlignCenter().Text(keyPage.LetterKeys[26].getString());
                            table.Cell().Row(19).Text(string.Empty);
                            table.Cell().Row(20).Column(1).AlignCenter().Text(keyPage.LetterKeys[27].getString());
                            table.Cell().Row(20).Column(2).AlignCenter().Text(keyPage.LetterKeys[28].getString());


                        });
                    });
                }
            });

            return document;
        }
        public IDocument CreateOutpostPagesPDF(List<OutpostModel> outposts, List<GroupModel> groups)
        {
            var document = Document.Create(container =>
            {
                foreach (GroupModel group in groups)
                {
                    OutpostModel tempOutpost = outposts[1];
                    outposts.RemoveAt(1);
                    outposts.Add(tempOutpost);
                    for (int i = 0; i < Math.Ceiling(outposts.Count / 2.0); i++)
                    {
                        container.Page(page =>
                        {
                            page.Size(PageSizes.A4);
                            
                            page.DefaultTextStyle(x => x.FontSize(14));

                            page.Content().Column(c =>
                            {
                                c.Item().Height(421).Table(pageOne =>
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
                                        header.Cell().Row(1).ColumnSpan(5).AlignCenter().Text(outposts[i * 2].Name).SemiBold().FontSize(48);
                                        header.Cell().Row(2).ColumnSpan(5).AlignCenter().PaddingBottom(20).Text($"Gruppe {group.groupNumber}").FontSize(12);
                                    });

                                    if (i * 2 == outposts.Count - 1)
                                    {
                                        int rightHalf = outposts[0].Tasks.Count / 2;
                                        int leftHalf = outposts[0].Tasks.Count - rightHalf;

                                        for (int j = 0; j < leftHalf; j++)
                                        {
                                            pageOne.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignLeft().PaddingLeft(75).PaddingVertical(5).Text($"{j + 1}) {outposts[0].Tasks[j].Question}");
                                            pageOne.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("__________");
                                        }
                                        for (int j = 0; j < rightHalf; j++)
                                        {
                                            pageOne.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignLeft().PaddingLeft(75).PaddingVertical(5).Text($"{leftHalf + j + 1}) {outposts[0].Tasks[leftHalf + j].Question}");
                                            pageOne.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("__________");
                                        }
                                        for (int j = 0; j < (8 - leftHalf); j++)
                                        {
                                            pageOne.Cell().Row((uint)leftHalf + (uint)j).PaddingVertical(5).Text(" ");
                                        }
                                    }
                                    else
                                    {
                                        int rightHalf = outposts[i * 2 + 1].Tasks.Count / 2;
                                        int leftHalf = outposts[i * 2 + 1].Tasks.Count - rightHalf;

                                        for (int j = 0; j < leftHalf; j++)
                                        {
                                            pageOne.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignLeft().PaddingLeft(75).PaddingVertical(5).Text($"{j + 1}) {outposts[i * 2 + 1].Tasks[j].Question}");
                                            pageOne.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("__________");
                                        }
                                        for (int j = 0; j < rightHalf; j++)
                                        {
                                            pageOne.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignLeft().PaddingLeft(75).PaddingVertical(5).Text($"{leftHalf + j + 1}) {outposts[i * 2 + 1].Tasks[leftHalf + j].Question}");
                                            pageOne.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("__________");
                                        }
                                        for (int j = 0; j < (8-leftHalf); j++)
                                        {
                                            pageOne.Cell().Row((uint)leftHalf + (uint)j).PaddingVertical(5).Text(" ");
                                        }
                                    }

                                    pageOne.Footer(footer =>
                                    {
                                        if (i * 2 == outposts.Count - 1)
                                        {
                                            footer.Cell().Row(1).ColumnSpan(5).AlignCenter().Text(outposts[0].ReturnNameUnderscored()).FontSize(48);
                                        }
                                        else
                                        {
                                            footer.Cell().Row(1).ColumnSpan(5).AlignCenter().Text(outposts[i * 2 + 1].ReturnNameUnderscored()).FontSize(48);
                                        }
                                        var scissorImage = File.ReadAllBytes("wwwroot/Images/ScissorIcon.png");
                                        footer.Cell().Row(2).Column(1).AlignLeft().PaddingLeft(10).Height(5, Unit.Millimetre).Image(scissorImage).FitHeight();
                                        footer.Cell().Row(2).ColumnSpan(5).AlignCenter()
                                        .Text("--------------------------------------------------------------------------------------------------------------------------------")
                                        .FontSize(12);
                                    });
                                });

                                c.Item().Height(421).Table(pageTwo =>
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
                                            if (i * 2 + 1 > outposts.Count - 1)
                                            {

                                            }
                                            else
                                            {
                                                header.Cell().Row(1).ColumnSpan(5).AlignCenter().Text(outposts[i * 2 + 1].Name).SemiBold().FontSize(48);
                                                header.Cell().Row(2).ColumnSpan(5).AlignCenter().PaddingBottom(20).Text($"Gruppe {group.groupNumber}").FontSize(12);
                                            }
                                        });

                                        if (i * 2 + 1 > outposts.Count - 1)
                                        {

                                        }
                                        else if (i * 2 + 1 == outposts.Count - 1)
                                        {
                                            int rightHalf = outposts[0].Tasks.Count / 2;
                                            int leftHalf = outposts[0].Tasks.Count - rightHalf;

                                            for (int j = 0; j < leftHalf; j++)
                                            {
                                                pageTwo.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignLeft().PaddingLeft(75).PaddingVertical(5, Unit.Point).Text($"{j + 1}) {outposts[0].Tasks[j].Question}");
                                                pageTwo.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("__________");
                                            }
                                            for (int j = 0; j < rightHalf; j++)
                                            {
                                                pageTwo.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignLeft().PaddingLeft(75).PaddingVertical(5, Unit.Point).Text($"{leftHalf + j + 1}) {outposts[0].Tasks[leftHalf + j].Question}");
                                                pageTwo.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("__________");
                                            }
                                            for (int j = 0; j < (8 - leftHalf); j++)
                                            {
                                                pageTwo.Cell().Row((uint)leftHalf + (uint)j).PaddingVertical(5).Text(" ");
                                            }
                                        }
                                        else
                                        {
                                            int rightHalf = outposts[i * 2 + 2].Tasks.Count / 2;
                                            int leftHalf = outposts[i * 2 + 2].Tasks.Count - rightHalf;

                                            for (int j = 0; j < leftHalf; j++)
                                            {
                                                pageTwo.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignLeft().PaddingLeft(75).PaddingVertical(5, Unit.Point).Text($"{j + 1}) {outposts[i * 2 + 2].Tasks[j].Question}");
                                                pageTwo.Cell().Row((uint)j + 1).Column(1).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("__________");
                                            }
                                            for (int j = 0; j < rightHalf; j++)
                                            {
                                                pageTwo.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignLeft().PaddingLeft(75).PaddingVertical(5, Unit.Point).Text($"{leftHalf + j + 1}) {outposts[i * 2 + 2].Tasks[leftHalf + j].Question}");
                                                pageTwo.Cell().Row((uint)j + 1).Column(3).ColumnSpan(3).AlignRight().PaddingRight(75).PaddingVertical(5).Text("__________");
                                            }
                                            for (int j = 0; j < (8 - leftHalf); j++)
                                            {
                                                pageTwo.Cell().Row((uint)leftHalf + (uint)j).PaddingVertical(5).Text(" ");
                                            }
                                        }

                                        pageTwo.Footer(footer =>
                                        {
                                            if (i * 2 + 1 > outposts.Count - 1)
                                            {

                                            }
                                            else if (i * 2 + 1 == outposts.Count - 1)
                                            {
                                                footer.Cell().ColumnSpan(5).AlignCenter().Text(outposts[0].ReturnNameUnderscored()).FontSize(48);
                                            }
                                            else
                                            {
                                                footer.Cell().ColumnSpan(5).AlignCenter().Text(outposts[i * 2 + 2].ReturnNameUnderscored()).FontSize(48);
                                            }
                                        });

                                });

                            });
                        });
                    }
                }
            });
            return document;
        }
    }
}
