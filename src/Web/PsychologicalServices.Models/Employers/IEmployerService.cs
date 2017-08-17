using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Employers
{
    public interface IEmployerService
    {
        Employer GetEmployer(int id);

        EmployerType GetEmployerType(int id);

        IEnumerable<Employer> GetEmployers(EmployerSearchCriteria criteria);

        IEnumerable<EmployerType> GetEmployerTypes(bool? isActive = true);

        SaveResult<Employer> SaveEmployer(Employer employer);

        SaveResult<EmployerType> SaveEmployerType(EmployerType employerType);
    }
}
