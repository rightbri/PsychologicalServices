using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Colors;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Colors
{
    public class ColorRepository : RepositoryBase, IColorRepository
    {
        public ColorRepository(
            IDataAccessAdapterFactory dataAccessAdapterFactory
        ) : base(dataAccessAdapterFactory)
        {
        }

        public Color GetColor(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.Color
                    .Where(c => c.ColorId == id)
                    .SingleOrDefault()
                    .ToColor();
            }
        }

        public IEnumerable<Color> GetColors(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<ColorEntity>(
                        (ILLBLGenProQuery)
                        meta.Color
                        .Where(color => isActive == null || color.IsActive == isActive.Value)
                    )
                    .Select(color => color.ToColor())
                    .ToList();
            }
        }

        public int SaveColor(Color color)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = color.IsNew();

                var entity = new ColorEntity
                {
                    IsNew = isNew,
                    ColorId = color.ColorId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = color.Name;
                entity.HexCode = color.HexCode;
                entity.IsActive = color.IsActive;

                adapter.SaveEntity(entity, false);

                return entity.ColorId;
            }
        }
    }
}
