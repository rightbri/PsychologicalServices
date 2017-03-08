using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Colors
{
    public interface IColorService
    {
        Color GetColor(int id);

        IEnumerable<Color> GetColors(bool? isActive = true);

        SaveResult<Color> SaveColor(Color color);
    }
}
