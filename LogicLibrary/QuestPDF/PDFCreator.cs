using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace LogicLibrary.QuestPDF
{
    public class PDFCreator
    {
        public void CreateKeyPagePDF(KeyPageModel keyPage)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                    .Text(text =>
                    {
                        text.AlignCenter();
                        text.Span("Nøgle").SemiBold().FontSize(48);
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
                        table.Cell().Row(4).Column(1).AlignCenter().Text($"A = {keyPage.LetterKeys[3].KeyNumber}");
                        table.Cell().Row(4).Column(2).AlignCenter().Text($"B = {keyPage.LetterKeys[4].KeyNumber}");
                        table.Cell().Row(4).Column(3).AlignCenter().Text($"C = {keyPage.LetterKeys[5].KeyNumber}");


                    });
                });
            });

            document.GeneratePdf("Nøgle.pdf");
        }
    }
}
