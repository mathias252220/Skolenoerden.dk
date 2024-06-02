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
                            table.Cell().Row(2).Column(1).AlignCenter().Text($"A = {keyPage.LetterKeys[0].KeyNumber}");
                            table.Cell().Row(2).Column(2).AlignCenter().Text($"B = {keyPage.LetterKeys[1].KeyNumber}");
                            table.Cell().Row(2).Column(3).AlignCenter().Text($"C = {keyPage.LetterKeys[2].KeyNumber}");
                            table.Cell().Row(3).Text(string.Empty);
                            table.Cell().Row(4).Column(1).AlignCenter().Text($"D = {keyPage.LetterKeys[3].KeyNumber}");
                            table.Cell().Row(4).Column(2).AlignCenter().Text($"E = {keyPage.LetterKeys[4].KeyNumber}");
                            table.Cell().Row(4).Column(3).AlignCenter().Text($"F = {keyPage.LetterKeys[5].KeyNumber}");
                            table.Cell().Row(5).Text(string.Empty);
                            table.Cell().Row(6).Column(1).AlignCenter().Text($"G = {keyPage.LetterKeys[6].KeyNumber}");
                            table.Cell().Row(6).Column(2).AlignCenter().Text($"H = {keyPage.LetterKeys[7].KeyNumber}");
                            table.Cell().Row(6).Column(3).AlignCenter().Text($"I = {keyPage.LetterKeys[8].KeyNumber}");
                            table.Cell().Row(7).Text(string.Empty);
                            table.Cell().Row(8).Column(1).AlignCenter().Text($"J = {keyPage.LetterKeys[9].KeyNumber}");
                            table.Cell().Row(8).Column(2).AlignCenter().Text($"K = {keyPage.LetterKeys[10].KeyNumber}");
                            table.Cell().Row(8).Column(3).AlignCenter().Text($"L = {keyPage.LetterKeys[11].KeyNumber}");
                            table.Cell().Row(9).Text(string.Empty);
                            table.Cell().Row(10).Column(1).AlignCenter().Text($"M = {keyPage.LetterKeys[12].KeyNumber}");
                            table.Cell().Row(10).Column(2).AlignCenter().Text($"N = {keyPage.LetterKeys[13].KeyNumber}");
                            table.Cell().Row(10).Column(3).AlignCenter().Text($"O = {keyPage.LetterKeys[14].KeyNumber}");
                            table.Cell().Row(11).Text(string.Empty);
                            table.Cell().Row(12).Column(1).AlignCenter().Text($"P = {keyPage.LetterKeys[15].KeyNumber}");
                            table.Cell().Row(12).Column(2).AlignCenter().Text($"Q = {keyPage.LetterKeys[16].KeyNumber}");
                            table.Cell().Row(12).Column(3).AlignCenter().Text($"R = {keyPage.LetterKeys[17].KeyNumber}");
                            table.Cell().Row(13).Text(string.Empty);
                            table.Cell().Row(14).Column(1).AlignCenter().Text($"S = {keyPage.LetterKeys[18].KeyNumber}");
                            table.Cell().Row(14).Column(2).AlignCenter().Text($"T = {keyPage.LetterKeys[19].KeyNumber}");
                            table.Cell().Row(14).Column(3).AlignCenter().Text($"U = {keyPage.LetterKeys[20].KeyNumber}");
                            table.Cell().Row(15).Text(string.Empty);
                            table.Cell().Row(16).Column(1).AlignCenter().Text($"V = {keyPage.LetterKeys[21].KeyNumber}");
                            table.Cell().Row(16).Column(2).AlignCenter().Text($"W = {keyPage.LetterKeys[22].KeyNumber}");
                            table.Cell().Row(16).Column(3).AlignCenter().Text($"X = {keyPage.LetterKeys[23].KeyNumber}");
                            table.Cell().Row(17).Text(string.Empty);
                            table.Cell().Row(18).Column(1).AlignCenter().Text($"Y = {keyPage.LetterKeys[24].KeyNumber}");
                            table.Cell().Row(18).Column(2).AlignCenter().Text($"Z = {keyPage.LetterKeys[25].KeyNumber}");
                            table.Cell().Row(18).Column(3).AlignCenter().Text($"Æ = {keyPage.LetterKeys[26].KeyNumber}");
                            table.Cell().Row(19).Text(string.Empty);
                            table.Cell().Row(20).Column(1).AlignCenter().Text($"Ø = {keyPage.LetterKeys[27].KeyNumber}");
                            table.Cell().Row(20).Column(2).AlignCenter().Text($"Å = {keyPage.LetterKeys[28].KeyNumber}");


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
                    for (int i = 0; i < outposts.Count / 2; i++)
                    {
                        container.Page(page =>
                        {
                            page.Size(PageSizes.A4);

                            page.DefaultTextStyle(x => x.FontSize(20));

                            page.Content()
                            .Grid(grid =>
                            {
                                grid.Columns(12);

                                grid.Item(12).AlignCenter().Text(outposts[i].Name).SemiBold().FontSize(48);

                                grid.Item(12).AlignCenter().Text($"Gruppe {group.groupNumber}").FontSize(12);

                                if (i == outposts.Count - 1)
                                {
                                    int rightHalf = outposts[0].Tasks.Count / 2;
                                    int leftHalf = outposts[0].Tasks.Count - rightHalf;

                                    for (int j = 0; j < leftHalf; j++)
                                    {
                                        grid.Item().AlignCenter().PaddingVertical(5, Unit.Point).Text($"{j + 1}) {outposts[0].Tasks[j].Question}");
                                    }
                                    for (int j = 0; j < rightHalf; j++)
                                    {
                                        grid.Item().AlignCenter().PaddingVertical(5, Unit.Point).Text($"{leftHalf + j + 1}) {outposts[0].Tasks[leftHalf + j].Question}");
                                    }
                                }
                                else
                                {
                                    int rightHalf = outposts[i + 1].Tasks.Count / 2;
                                    int leftHalf = outposts[i + 1].Tasks.Count - rightHalf;

									for (int j = 0; j < leftHalf; j++)
									{
										grid.Item().AlignCenter().PaddingVertical(5, Unit.Point).Text($"{j + 1}) {outposts[i + 1].Tasks[j].Question}");
									}
									for (int j = 0; j < rightHalf; j++)
                                    {
                                        grid.Item().AlignCenter().PaddingVertical(5, Unit.Point).Text($"{leftHalf + j + 1}) {outposts[i + 1].Tasks[leftHalf + j].Question}");
                                    }
                                }
                            });

                            page.Footer()
                            .PaddingVertical(5, Unit.Point)
                            .Text(text =>
                            {
                                text.AlignCenter();
                                if (i == outposts.Count - 1)
                                {
                                    text.Span(outposts[0].ReturnNameUnderscored()).FontSize(48);
                                }
                                else
                                {
                                    text.Span(outposts[i + 1].ReturnNameUnderscored()).FontSize(48);
                                }
                            });

                        });
                    }
                }
            });
            return document;
        }
    }
}
