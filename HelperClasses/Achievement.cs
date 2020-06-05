using System.ComponentModel.DataAnnotations;

namespace FanGuide.HelperClasses
{
    public class Achievement
    {
        public int Id { get; set; }
        public AchievementType Type { get; set; }
    }
    public enum AchievementType : byte
    {
        [Display(Name = "Bronze Medal")]
        BronzeMedal,
        [Display(Name = "Silver Medal")]
        SilverMedal,
        [Display(Name = "Gold Medal")]
        GoldMedal,
    }
}