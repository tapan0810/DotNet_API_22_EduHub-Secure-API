using AutoMapper;
using DotNet_API_22_.Data;
using DotNet_API_22_.Entities.Dtos.SchoolDtos;
using DotNet_API_22_.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet_API_22_.Service.SchoolService
{
    public class SchoolService (EduHubDbContext _context,IMapper mapper): ISchoolService
    {
        public async Task<GetSchoolById?> CreateSchool(CreateSchoolDto school)
        {
            var sch = mapper.Map<School>(school);
            if (sch is null)
                return null;

            _context.Schools.Add(sch);
            await _context.SaveChangesAsync();

            return mapper.Map<GetSchoolById?>(sch);


        }

        public async Task<bool> DeleteSchool(int schoolId)
        {
            var school = await _context.Schools.FirstOrDefaultAsync(x => x.SchoolId == schoolId);
            if (school is null)
                return false;

            _context.Schools.Remove(school);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<GetAllSchoolDto>> GetAllSchool(int pageNumber,int pageSize)
        {
            var schools = await _context.Schools.ToListAsync();

            return mapper.Map<List<GetAllSchoolDto>>(schools).Skip((pageNumber - 1) * pageSize).ToList();
        }

        public async Task<GetSchoolById?> GetSchoolById(int schoolId)
        {
            var school = _context.Schools.FirstOrDefault(x => x.SchoolId == schoolId);

            if (school is null)
                throw new Exception("School Not Found");

            return mapper.Map<GetSchoolById?>(school);
        }

        public async Task<bool> UpdateSchool(int id,UpdateSchoolDto school)
        {
            var sch = await _context.Schools.FirstOrDefaultAsync(x => x.SchoolId == id);

            if (sch is null)
                throw new Exception("School not Found");

            mapper.Map(school, sch);

            await _context.SaveChangesAsync();

            return true;

        }
    }
}
