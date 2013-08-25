using System.Collections.Generic;

namespace ParadiseBookers.Models.Common
{    
    public class BarGraphModel
    {
        public BarGraphModel()
        {
            Sections = new List<BarGraphSection>();
        }

        public string Title { get; set; }

        public decimal MaxValue { get; set; }

        public List<BarGraphSection> Sections { get; set; } 
    }
}