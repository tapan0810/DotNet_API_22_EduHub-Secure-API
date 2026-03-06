using DotNet_API_22_.Entities.Dtos.SchoolDtos;

namespace DotNet_API_22_.Service.SchoolService
{
    public interface ISchoolService
    {
        public Task<List<GetAllSchoolDto>> GetAllSchool();
        public Task<GetSchoolById?> GetSchoolById(int schoolId);
        public Task<GetSchoolById?> CreateSchool(CreateSchoolDto school);
        public Task<bool> UpdateSchool(int id,UpdateSchoolDto school);
        public Task<bool> DeleteSchool(int schoolId);
    }
}
