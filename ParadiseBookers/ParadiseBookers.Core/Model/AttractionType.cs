using System.ComponentModel;

namespace ParadiseBookers.Core.Model
{
    public enum AttractionType
    {
        Activity,
        Tour,
        [Description("Historical Monument")]
        HistoricalMonument,
        Museum,
        Cultural
    }
}