using PsychologicalServices.Data.EntityClasses;
using PsychologicalServices.Data.Linq;
using PsychologicalServices.Infrastructure.Common.Repository;
using PsychologicalServices.Models.Cities;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Infrastructure.Cities
{
    public class CityRepository : RepositoryBase, ICityRepository
    {
        public CityRepository(
            IDataAccessAdapterFactory adapterFactory
        ) : base(adapterFactory)
        {
        }

        public City GetCity(int id)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return meta.City
                    .Where(c => c.CityId == id)
                    .SingleOrDefault()
                    .ToCity();
            }
        }

        public IEnumerable<City> GetCities(bool? isActive = true)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var meta = new LinqMetaData(adapter);

                return Execute<CityEntity>(
                        (ILLBLGenProQuery)
                        meta.City
                        .Where(c => isActive == null || c.IsActive == isActive)
                    )
                    .Select(c => c.ToCity())
                    .ToList();
            }
        }

        public int SaveCity(City city)
        {
            using (var adapter = AdapterFactory.CreateAdapter())
            {
                var isNew = city.IsNew();

                var entity = new CityEntity
                {
                    IsNew = isNew,
                    CityId = city.CityId,
                };

                if (!isNew)
                {
                    adapter.FetchEntity(entity);
                }

                entity.Name = city.Name;
                entity.Province = city.Province;
                entity.Country = city.Country;
                entity.IsActive = city.IsActive;

                adapter.SaveEntity(entity, false);

                return entity.CityId;
            }
        }
    }
}
