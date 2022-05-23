using DevExpress.Pdf;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Export.Pdf;
using DevExpress.XtraReports.UI;
using FishHoghoghi.Extensions;
using FishHoghoghi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Web;

namespace FishHoghoghi.Utilities
{
    public static class XRDocumentExtentions
    {
        public static void SetStyle(this XtraReport report, bool rightToLeft, bool Landscape, Font Font, Margins margins)
        {
            report.RightToLeft = rightToLeft ? RightToLeft.Yes : RightToLeft.No;

            report.Landscape = Landscape ? true : false;

            report.Font = Font;

            report.Margins = margins;
        }

        public static void SetDataSource(this XtraReport report, DataTable data)
        {
            report.DataSource = data;
        }

        public static void SetBands(this XtraReport report, XRControl[] controls)
        {
            ReportHeaderBand band = new ReportHeaderBand();

            band.Controls.AddRange(controls.Where(x => x != null).ToArray());

            report.Bands.Add(band);
        }

        public static void SetHeaderItem(this XRTableRow Row, List<ReportColumn> reportColumnList, string fontFamily, float? Size)
        {

            reportColumnList.Reverse();

            reportColumnList.ForEach(col =>
            {
                Row.AddCell(col.Title, fontFamily, Size);

            });

            reportColumnList.Reverse();
        }

        public static void AddCell(this XRTableRow Row, string data, string fontFamily, float? Size)
        {
            Row.Cells.Add(GenerateCell(data, false, 1.0, false, fontFamily, Size));
        }

        public static XRTableCell GenerateCell(string value, bool border, double w = 1.0, bool neverBorer = false, string fontFamily = "Tahoma", float? fontSize = 8, FontStyle? fontStyle = FontStyle.Regular)
        {
            string FontFamily = string.IsNullOrEmpty(fontFamily) ? "Tahoma" : fontFamily;

            float FontSize = (fontSize != null && fontSize != 0) ? (float)fontSize : 8;

            FontStyle FontStyle = (fontStyle != null) ? (FontStyle)fontStyle : FontStyle.Regular;

            XRTableCell cell = new XRTableCell();
            if (neverBorer)
            {
                cell.Borders = BorderSide.None;
            }
            else
            {
                cell.Borders = !border ? BorderSide.Left : BorderSide.Right;
            }

            cell.Font = new Font(string.IsNullOrEmpty(fontFamily) ? "Tahoma" : FontFamily, FontSize, FontStyle);

            cell.Multiline = true;

            cell.StylePriority.UseBorders = false;

            cell.StylePriority.UseFont = false;

            cell.Text = value;

            cell.Weight = w;

            return cell;
        }

        internal static XRLabel CreateLablel(LabelModel model)
        {
            return new XRLabel
            {
                AutoWidth = true,
                Borders = BorderSide.None,
                Font = new Font(model.FontFamily, model.FontSize, model.FontStyle),
                LocationFloat = model.LocationFloat,
                Name = model.Name,
                NullValueText = "-",
                Padding = model.PaddingInfo,
                RightToLeft = RightToLeft.Yes,
                SizeF = model.Size,
                StylePriority = {
                    UseBorders = false,
                    UseFont = false,
                    UseTextAlignment = false
                },
                Text = model.Title,
                TextAlignment = TextAlignment.MiddleCenter
            };
        }

        public static void SetStyle(this XRTableCell cell, BorderSide borders, TextAlignment textAlignment, PaddingInfo padding)
        {
            cell.SetBorder(borders);

            cell.TextAlignment = textAlignment;

            cell.Padding = padding;
        }

        public static void SetBorder(this XRTableCell cell, BorderSide borders)
        {
            cell.Borders = borders;
        }

        public static void SetStyleTable(this XRTable table, SizeF size, TextAlignment textAlignment, Color? backColor)
        {
            table.BackColor = backColor == null ? Color.White : (Color)backColor;

            /*   Borders = border,*/

            table.SizeF = size;

            table.TextAlignment = textAlignment;

        }

        public static void SetLocation(this XRTable table, PointFloat location)
        {
            table.LocationF = location;
        }

        public static void AddRow(this XRTable table, XRTableRow row)
        {
            table.Rows.Add(row);
        }

        public static void SetCellBorder(this XRTableRow Row, BorderSide borders)
        {
            foreach (XRControl control in Row.Cells)
            {
                control.Borders = borders;
            }
        }

        public static void SetPadding(this XRTableRow Row, PaddingInfo padding)
        {
            Row.Padding = padding;
        }

        internal static XRPictureBox AddImage(string imagePath, PointFloat pointFloat)
        {
            Image newImage = Image.FromFile(imagePath);
            return new XRPictureBox
            {
                Image = newImage,
                Borders = BorderSide.None,
                LocationFloat = pointFloat,
                Name = "Logo",
                NullValueText = "Logo",
                Padding = new PaddingInfo(120, 2, 0, 0, 300f),
                RightToLeft = RightToLeft.Yes,
                SizeF = new SizeF(150f, 110f),
                StylePriority = {
                    UseBorders = false,
                    UseFont = false,
                    UseTextAlignment = false
                },
                ImageAlignment = ImageAlignment.TopLeft,
                Sizing = ImageSizeMode.StretchImage


            };

        }

    }
}