using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using PointOfSale.Models;

namespace PointOfSale.Helpers
{
    public static class Printing
    {
        private static readonly PointOfSaleContext _db = new PointOfSaleContext();
        private static PrintDocument _pdoc = null;

        private static Rectangle Rectangle(int x, int y, int width, int height)
        {
            return new Rectangle(x, y, width, height);
        }

        private static void PdocOnPrintPage(int? id, string category, Graphics graphics, int width = 400)
        {
            var largeFont = new Font("Arial", 22, FontStyle.Bold);
            var mediumFont = new Font("Arial", 14);
            var mediumFontBold = new Font("Arial", 12, FontStyle.Bold);
            var smallFont = new Font("Arial", 12);
            var smallFontBold = new Font("Arial", 12, FontStyle.Bold);

            var smallFontHeight = Convert.ToInt32(smallFont.GetHeight());
            var largeFontHeight = Convert.ToInt32(largeFont.GetHeight());
            var mediumFontHeight = Convert.ToInt32(mediumFont.GetHeight());

            var brush = new SolidBrush(Color.Black);
            var blueBrush = new SolidBrush(Color.SteelBlue);
            var dashPen = new Pen(Color.Black) { DashStyle = DashStyle.Solid };

            const int startX = 50;
            var offset = 60;

            var alignLeft = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };
            var alignCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            var alignRight = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far };

            object obj = null;
            DateTime date = DateTime.Now;
            decimal? amount = null;
            var currency = string.Empty;
            List<GeneralJournal> items = null;
            string remarks = null;
            Company company = null;

            Rectangle rectangle;

            switch (category)
            {
                case "Receipt":
                    obj = _db.Receipts.Include(q => q.Company).Include(q => q.Journals).Include(q => q.Journals.Select(j => j.Product)).Include(c => c.Currency).First(q => q.Id == id);
                    var receipt = (Receipt)obj;
                    company = receipt.Company;
                    date = receipt.DateCreated;
                    items = receipt.Journals.ToList();
                    currency = receipt.Currency?.Code;
                    remarks = receipt.Remarks;
                    break;

                case "Invoice":
                    obj = _db.Invoices.Include(q => q.Company).Include(q => q.Journals).Include(q => q.Journals.Select(j => j.Product)).Include(c => c.Currency).First(q => q.Id == id);
                    var invoice = (Invoice)obj;
                    company = invoice.Company;
                    date = invoice.DateCreated;
                    items = invoice.Journals.Where(j => !j.ReceiptId.HasValue && !j.VoucherId.HasValue).ToList();
                    currency = invoice.Currency?.Code;
                    remarks = invoice.Remarks;
                    break;

                case "Voucher":
                    obj = _db.Vouchers.Include(q => q.Company).Include(q => q.Journals).Include(q => q.Journals.Select(j => j.Product)).Include(c => c.Currency).First(q => q.Id == id);
                    var voucher = (Voucher)obj;
                    company = voucher.Company;
                    date = voucher.DateCreated;
                    items = voucher.Journals.ToList();
                    currency = voucher.Currency?.Code;
                    remarks = voucher.Remarks;
                    break;

                case "Memo":
                    obj = _db.Memos.Include(q => q.Company).Include(q => q.Journals).Include(q => q.Journals.Select(j => j.Product)).Include(c => c.Currency).First(q => q.Id == id);
                    var memo = (Memo)obj;
                    company = memo.Company;

                    date = memo.DateCreated;
                    items = memo.Journals.ToList();
                    currency = memo.Currency?.Code;
                    remarks = memo.Remarks;
                    break;
                default:
                    break;
            }

            width = width - startX;
            var lineWidth = width + 30;
            rectangle = Rectangle(startX, offset, width, largeFontHeight);
            graphics.DrawString(category, largeFont, brush, rectangle, alignLeft);

            offset = offset + 2 * largeFontHeight;

            rectangle = Rectangle(startX + width / 4, offset + 25, -10 + width / 4, smallFontHeight);
            graphics.DrawString("From", smallFont, brush, rectangle, alignRight);

            graphics.DrawLine(dashPen, new Point(startX - 5 + width / 2, offset), new Point(startX - 5 + width / 2, offset + 120));

            rectangle = Rectangle(startX + width / 2, offset, width / 2, mediumFontHeight);
            graphics.DrawString(Session.Tenant.Name.ToUpper(), mediumFontBold, blueBrush, rectangle, alignLeft);

            offset = offset + rectangle.Height;
            rectangle = Rectangle(startX + width / 2, offset, width / 2, mediumFontHeight);
            graphics.DrawString("TIN: " + Session.Tenant.Tin, smallFont, brush, rectangle, alignLeft);

            offset = offset + rectangle.Height;
            rectangle = Rectangle(startX + width / 2, offset, width / 2, largeFontHeight);
            graphics.DrawString(Session.Tenant.Address, smallFont, brush, rectangle, alignLeft);

            offset = offset + rectangle.Height;
            rectangle = Rectangle(startX + width / 2, offset, width / 2, mediumFontHeight);
            graphics.DrawString(Session.Tenant.Telephone, smallFont, brush, rectangle, alignLeft);

            offset = offset + rectangle.Height;
            rectangle = Rectangle(startX + width / 2, offset, width / 2, mediumFontHeight);
            graphics.DrawString(Session.Tenant.Email, smallFont, brush, rectangle, alignLeft);

            offset = offset + 20 + rectangle.Height;

            rectangle = Rectangle(startX, offset, -10 + width / 8, mediumFontHeight);
            graphics.DrawString("Client", smallFont, brush, rectangle, alignRight);

            graphics.DrawLine(dashPen, new Point(startX - 5 + width / 8, offset - 10), new Point(startX - 5 + width / 8, offset + 60));

            rectangle = Rectangle(startX + width / 8, offset, 3 * width / 8, mediumFontHeight);
            graphics.DrawString(company?.Name.ToUpper(), mediumFontBold, blueBrush, rectangle, alignLeft);

            rectangle = Rectangle(startX + width / 8, offset + rectangle.Height + 5, 3 * width / 8, mediumFontHeight);
            graphics.DrawString(company?.Address, mediumFontBold, brush, rectangle, alignLeft);

            // =============================================

            rectangle = Rectangle(startX + width / 4, offset, -10 + width / 4, mediumFontHeight);
            graphics.DrawString("Invoice #", smallFont, brush, rectangle, alignRight);

            rectangle = Rectangle(startX + width / 4, offset + rectangle.Height + 5, -10 + width / 4, mediumFontHeight);
            graphics.DrawString("Issue Date", smallFont, brush, rectangle, alignRight);

            graphics.DrawLine(dashPen, new Point(startX - 5 + width / 2, offset - 10), new Point(startX - 5 + width / 2, offset + 60));

            rectangle = Rectangle(startX + width / 2, offset, width / 2, mediumFontHeight);
            graphics.DrawString(id.ToString(), mediumFontBold, blueBrush, rectangle, alignLeft);

            rectangle = Rectangle(startX + width / 2, offset + rectangle.Height + 5, width / 2, mediumFontHeight);
            graphics.DrawString(date.ToString("dd-MM-yyyy"), mediumFontBold, brush, rectangle, alignLeft);

            offset = offset + 6 * rectangle.Height;
            graphics.DrawLine(dashPen, new Point(startX, offset), new Point(lineWidth, offset));

            offset = offset + rectangle.Height;
            rectangle = Rectangle(startX, offset, width / 2, largeFontHeight);
            graphics.DrawString("Item", smallFontBold, brush, rectangle, alignLeft);

            rectangle = Rectangle(startX + width / 2, offset, width / 6, largeFontHeight);
            graphics.DrawString("Qty", smallFontBold, brush, rectangle, alignLeft);

            rectangle = Rectangle(startX + 2 * width / 3, offset, width / 6, largeFontHeight);
            graphics.DrawString("Unit Price", smallFontBold, brush, rectangle, alignLeft);

            rectangle = Rectangle(startX + width / 2 + width / 3, offset, width / 6, largeFontHeight);
            graphics.DrawString("Amount", smallFontBold, brush, rectangle, alignLeft);

            offset = offset + rectangle.Height;

            graphics.DrawLine(dashPen, new Point(startX, offset), new Point(lineWidth, offset));

            if (items != null)
            {
                foreach (var item in items)
                {
                    var particulars = item.Particulars;
                    offset = offset + largeFontHeight;
                    graphics.DrawString(particulars, smallFont, brush, Rectangle(startX, offset, width / 2, largeFontHeight), alignLeft);

                    if (item.Quantity != null)
                        graphics.DrawString(item.Quantity.Value.ToString("N0"),
                            smallFont, brush, Rectangle(startX + width / 2, offset, width / 6, largeFontHeight), alignLeft);

                    if (item.Product.SellPrice != null)
                        graphics.DrawString(item.Product.SellPrice.Value.ToString("N0"),
                            smallFont, brush, Rectangle(startX + 2 * width / 3, offset, width / 6, largeFontHeight), alignLeft);

                    if (item.Amount != null)
                        graphics.DrawString(item.Amount.Value.ToString("N0"),
                            smallFont, brush, Rectangle(startX + width / 2 + width / 3, offset, width / 6, largeFontHeight), alignLeft);
                }
                amount = items.Sum(s => s.Amount);
            }

            offset = offset + largeFontHeight;
            if (amount != null)
            {
                var grosstotal = currency + " " + amount.Value.ToString("N0");

                offset = offset + largeFontHeight;
                graphics.DrawLine(dashPen, new Point(startX, offset), new Point(lineWidth, offset));

                offset = offset + largeFontHeight;
                graphics.DrawString("Total Amount", smallFontBold,
                    brush, Rectangle(startX, offset, width / 2, largeFontHeight), alignLeft);

                graphics.DrawString(grosstotal, smallFont,
                    brush, Rectangle(startX + width / 2, offset, width / 2, largeFontHeight), alignLeft);

                offset = offset + largeFontHeight;
                graphics.DrawLine(dashPen, new Point(startX, offset), new Point(lineWidth, offset));
            }

            offset = offset + 2 * largeFontHeight;
            graphics.DrawString("Remarks", smallFontBold, brush, Rectangle(startX, offset, width, largeFontHeight), alignLeft);

            offset = offset + largeFontHeight;
            graphics.DrawString(remarks, smallFont, brush, Rectangle(startX, offset, width, largeFontHeight), alignLeft);

            offset = offset + 2 * largeFontHeight;
            var drawnBy = Session.FullName;

            graphics.DrawString(drawnBy, smallFont, brush, Rectangle(startX, offset, width, largeFontHeight), alignLeft);
        }

        public static void Preview(int? id, string category)
        {
            var printDialog = new PrintDialog();
            _pdoc = new PrintDocument();
            var settings = new PrinterSettings();

            _pdoc.PrinterSettings = settings;
            var paperSizes = settings.PaperSizes.Cast<PaperSize>();
            var size = paperSizes.First<PaperSize>(s => s.Kind == PaperKind.A4);
            var width = size.Width;

            printDialog.Document = _pdoc;

            _pdoc.PrintPage += (sender, args) => PdocOnPrintPage(id, category, args.Graphics, width);

            var pp = new PrintPreviewDialog
            {
                Document = _pdoc,
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen,
                Text = category,
                ShowIcon = false,
                PrintPreviewControl =
                {
                    AutoZoom = true,
                    Zoom = 1.0
                }
            };

            // Hide the top bar
            ((ToolStrip)pp.Controls[1]).Visible = false;

            pp.ShowDialog();
        }

        public static void Print(int? id, string category, int width)
        {
            var printDialog = new PrintDialog();
            _pdoc = new PrintDocument();
            var settings = new PrinterSettings();

            _pdoc.PrinterSettings = settings;

            printDialog.Document = _pdoc;

            _pdoc.PrintPage += (sender, args) => PdocOnPrintPage(id, category, args.Graphics, width);

            var result = printDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _pdoc.Print();
            }
        }
    }
}
