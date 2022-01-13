namespace TaxLib.Base.Model
{
    public class Message
    {
        public string FilePath { get; set; }

        public string Body { get; set; }

        public MessageType Type { get; set; }
    }
}
