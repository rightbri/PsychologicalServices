using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Employers
{
    public interface IEmployerRepository
    {
        Employer GetEmployer(int id);

        EmployerType GetEmployerType(int id);

        IEnumerable<Employer> GetEmployers(EmployerSearchCriteria criteria);

        IEnumerable<EmployerType> GetEmployerTypes(bool? isActive = true);

        int SaveEmployer(Employer employer);

        int SaveEmployerType(EmployerType employerType);
    }
}
