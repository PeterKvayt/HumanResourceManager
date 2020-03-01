using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using ExceptionClasses.Loggers;
using System;

namespace DataAccessLayer.Repositories
{
    class CompanyRepository : GeneralRepository<Company>, ICompanyRepository<Company>
    {
        public CompanyRepository(IHrmContext inputСontext)
        {
            _context = inputСontext.CompanyContext;
        }

        public int GetSize(Company company)
        {
            try
            {
                return _context.GetSize(company);
            }
            catch (Exception)
            {
                string EXCEPTION_MESSAGE = $"Ошибка получения размера компании в классе CompanyRepository!";

                ExceptionLogger.LogError(EXCEPTION_MESSAGE);

                throw;
            }
        }
    }
}
