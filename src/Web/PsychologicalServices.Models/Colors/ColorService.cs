using log4net;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Colors
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository = null;
        private readonly IColorValidator _colorValidator = null;
        private readonly ILog _log = null;

        public ColorService(
            IColorRepository colorRepository,
            IColorValidator colorValidator,
            ILog log
        )
        {
            _colorRepository = colorRepository;
            _colorValidator = colorValidator;
            _log = log;
        }

        public Color GetColor(int id)
        {
            var color = _colorRepository.GetColor(id);

            return color;
        }

        public IEnumerable<Color> GetColors(bool? isActive = true)
        {
            var colors = _colorRepository.GetColors(isActive);

            return colors;
        }

        public SaveResult<Color> SaveColor(Color color)
        {
            var result = new SaveResult<Color>();

            try
            {
                var validation = _colorValidator.Validate(color);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _colorRepository.SaveColor(color);

                    result.Item = _colorRepository.GetColor(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveColor", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
