namespace FanGuide.HelperClasses
{
    public class Sex
    {
        public int Id { get; set; }
        public SexType Type { get; set; }
    }
    public enum SexType : byte
    {
        Woman,
        Man
    }
}