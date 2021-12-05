using DevExpress.Utils;
using DevExpress.XtraPrinting;
using System.Drawing;

namespace FishHoghoghi.Models
{
    public class LabelModel
    {
        public float FontSize { get; set; }

        public FontStyle FontStyle { get; set; }

        public PointFloat LocationFloat { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string FontFamily { get; set; }

        public PaddingInfo PaddingInfo { get; set; }

        public SizeF Size { get; set; }

        public bool MultiLine { get; set; }


        public LabelModel(PointFloat locationFloat, string name, PaddingInfo paddingInfo, SizeF size, string title, float? fontSize = 8, FontStyle? fontStyle = FontStyle.Regular, string fontFamily = "Tahoma")
        {
            FontSize = fontSize != null && fontSize != 0 ? (float)fontSize : 8;

            FontFamily = string.IsNullOrEmpty(fontFamily) ? "Tahoma" : fontFamily;

            LocationFloat = locationFloat;

            FontStyle = fontStyle != null ? (FontStyle)fontStyle : FontStyle.Regular;

            PaddingInfo = paddingInfo != null ? paddingInfo : new PaddingInfo(0, 2, 0, 0);

            Size = size;

            Name = name;

            Title = title;

        }

        public LabelModel(PointFloat locationFloat, string name, PaddingInfo paddingInfo, SizeF size, string title, float fontSize = 8, string fontFamily = "Tahoma")
        {
            FontSize = fontSize;

            FontFamily = string.IsNullOrEmpty(fontFamily) ? "Tahoma" : fontFamily;

            LocationFloat = locationFloat;

            FontStyle = FontStyle.Regular;

            PaddingInfo = paddingInfo != null ? paddingInfo : new PaddingInfo(0, 2, 0, 0);

            Size = size;

            Name = name;

            Title = title;

        }

        public LabelModel(PointFloat locationFloat, string name, SizeF size, string title)
        {
            FontSize = 8f;

            FontFamily = "Tahoma";

            LocationFloat = locationFloat;

            FontStyle = FontStyle.Regular;

            PaddingInfo = new PaddingInfo(0, 2, 0, 0);

            Size = size;

            Name = name;

            Title = title;

        }

        public LabelModel(PointFloat locationFloat, string name, PaddingInfo paddingInfo, SizeF size, string title, FontStyle fontStyle)
        {
            FontSize = 8f;

            FontFamily = "Tahoma";

            LocationFloat = locationFloat;

            FontStyle = fontStyle;

            PaddingInfo = paddingInfo;

            Size = size;

            Name = name;

            Title = title;

        }

        public LabelModel(PointFloat locationFloat, string name, PaddingInfo paddingInfo, SizeF size, string title, string fontFamily)
        {
            FontSize = 8f;

            FontFamily = fontFamily;

            LocationFloat = locationFloat;

            FontStyle = FontStyle.Regular;

            PaddingInfo = paddingInfo;

            Size = size;

            Name = name;

            Title = title;

        }

        public LabelModel(PointFloat locationFloat, string name, PaddingInfo paddingInfo, SizeF size, string title, bool multiLine, float? fontSize = 8, FontStyle fontStyle = FontStyle.Regular, string fontFamily = "Tahoma")
        {
            FontSize = fontSize != null && fontSize != 0 ? (float)fontSize : 8;

            FontFamily = string.IsNullOrEmpty(fontFamily) ? "Tahoma" : fontFamily;

            LocationFloat = locationFloat;

            FontStyle = fontStyle;

            PaddingInfo = paddingInfo != null ? paddingInfo : new PaddingInfo(0, 2, 0, 0);

            Size = size;

            Name = name;

            Title = title;

            MultiLine = multiLine;
        }

    }
}
