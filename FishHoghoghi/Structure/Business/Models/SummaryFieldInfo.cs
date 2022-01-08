namespace FishHoghoghi.Business.Models
{
    public class SummaryFieldInfo
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Postfix { get; set; }

        public bool IsRequire { get; set; } = true;
        
        public bool IsNumber { get; set; } = false;

        public bool IsHourNumber { get; set; } = false;

        public bool IsString { get; set; } = true;

        public bool IsDecimal { get; set; } = false;

        public SummaryFieldInfo()
        {
        }

        public SummaryFieldInfo(string name) : this(name, string.Empty)
        {
        }

        public SummaryFieldInfo(string name, string postfix) : this(name, name, postfix)
        {
        }

        public SummaryFieldInfo(string name, string title, string postfix)
        {
            Name = name;

            Title = title;
        }
    }
}