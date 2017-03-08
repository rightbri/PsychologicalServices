using System;

namespace PsychologicalServices.Models.Colors
{
    public class Color
    {
        public int ColorId { get; set; }

        public string Name { get; set; }

        public string HexCode { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return ColorId == 0;
        }
    }
}
