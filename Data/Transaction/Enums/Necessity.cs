using System.ComponentModel;

namespace Data.BankAtivity.Enums
{
    public enum Necessity
    {
        [Description("Very unnecessary")]
        VeryUnnecessary,
        [Description("Unnecessary")]
        Unnecessary,
        [Description("Rather unnecessary")]
        RatherUnnecessary,
        [Description("Neutral")]
        Neutral,
        [Description("Rather necessary")]
        RatherNecessary,
        [Description("Necessary")]
        Necessary,
        [Description("Very necessary")]
        VeryNecessary,
    }
}
