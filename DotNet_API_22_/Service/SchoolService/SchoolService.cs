using AutoMapper;
using DotNet_API_22_.Data;
using DotNet_API_22_.Entities.Dtos.SchoolDtos;
using DotNet_API_22_.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace DotNet_API_22_.Service.SchoolService
{
    public class SchoolService (EduHubDbContext _context,IMapper mapper,IDistributedCache cache): ISchoolService
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
            string cachekey = $"schools_{pageNumber}_{pageSize}";

            //Check cache data
            var cacheData = await cache.GetStringAsync(cachekey);

            //If Cache has data then return the data skip the db queries
            if(cacheData != null)
            {
                return JsonSerializer.Deserialize<List<GetAllSchoolDto>>(cacheData)!;
            }

            //Delay to check Redis
            await Task.Delay(5000);

            var schools = await _context.Schools
                .OrderBy(x => x.SchoolId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var result =  mapper.Map<List<GetAllSchoolDto>>(schools);

            //Save to redis
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            await cache.SetStringAsync(cachekey, JsonSerializer.Serialize(result), options);

            return result;
        }

        public async Task<GetSchoolById?> GetSchoolById(int schoolId)
        {
            var school =await _context.Schools.FirstOrDefaultAsync(x => x.SchoolId == schoolId);

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
