using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models.Repository
{
    public class CheckUpsServicesReposatory : IAutoRepository<CheckUpsServices>
    {

        readonly AutoCareContext _AutoCheckUpsContext;
        public CheckUpsServicesReposatory(AutoCareContext context)
        {
            _AutoCheckUpsContext = context;
        }
        public async Task<IEnumerable<CheckUpsServices>> GetAll()
        {
            return await _AutoCheckUpsContext.CheckUpsServices.ToListAsync();
        }
        public async Task<CheckUpsServices> Get(long? id)
        {
            return await _AutoCheckUpsContext.CheckUpsServices
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<int> Add(CheckUpsServices entity)
        {
            entity.CreateOn = DateTime.Now;
            entity.ModifiedOn = DateTime.Now;
            await _AutoCheckUpsContext.CheckUpsServices.AddAsync(entity);
            return await _AutoCheckUpsContext.SaveChangesAsync();
        }
        public async Task<int> Update(long id, CheckUpsServices entity)
        {
            var oldCheckUp = await Get(id);

            entity.ModifiedOn = DateTime.Now;
            oldCheckUp.CarCheckUps = entity.CarCheckUps;
            oldCheckUp.CheckUpsId = entity.CheckUpsId;
            oldCheckUp.CarService = entity.CarService;
            oldCheckUp.ServicesId = entity.ServicesId;
            
            return await _AutoCheckUpsContext.SaveChangesAsync();
        }
        public async Task<int> Delete(CheckUpsServices checkUpsServices)
        {
            _AutoCheckUpsContext.CheckUpsServices.Remove(checkUpsServices);
            return await _AutoCheckUpsContext.SaveChangesAsync();
        }
    }
}
