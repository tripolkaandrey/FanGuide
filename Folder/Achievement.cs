namespace FanGuide.Folder
{
    public class Achievement
    {
        public int Id { get; set; }
        public AchievementType Type { get; set; }
    }
    public enum AchievementType : byte
    {
        GoldMedal,
        SilverMedal,
        BronzeMedal,
    }
}