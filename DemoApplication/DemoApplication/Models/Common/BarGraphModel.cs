using System.Collections.Generic;

namespace DemoApplication.Models.Common
{    
    public class BarGraphModel
    {
        public BarGraphModel()
        {
            Sections = new List<BarGraphSection>();
        }

        public string Title { get; set; }

        public int MaxValue { get; set; }

        public List<BarGraphSection> Sections { get; set; } 
    }
}