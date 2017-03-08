using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Colors
{
    public interface IColorRepository
    {
        Color GetColor(int id);

        IEnumerable<Color> GetColors(bool? isActive = true);

        int SaveColor(Color color);
    }
}
