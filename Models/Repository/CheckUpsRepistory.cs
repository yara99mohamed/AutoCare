using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models.Repository
{
    public class CheckUpsRepoistory : IAutoRepository<CheckUps>
    {
        readonly AutoCareContext _AutoCheckUpsContext;
        public CheckUpsRepoistory(AutoCareContext context)
        {
            _AutoCheckUpsContext = context;
        }
        public async Task<IEnumerable<CheckUps>> GetAll()
        {
            return await _AutoCheckUpsContext.CheckUps.ToListAsync();
        }
        public async Task<CheckUps> Get(long? id)
        {
            return await _AutoCheckUpsContext.CheckUps.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<int> Add(CheckUps entity)
        {
            entity.CreateOn = DateTime.Now;
            entity.ModifiedOn = DateTime.Now;
            await _AutoCheckUpsContext.CheckUps.AddAsync(entity);
            return await _AutoCheckUpsContext.SaveChangesAsync();
        }
        public async Task<int> Update(long id, CheckUps entity)
        {
            var oldCheckUp = await Get(id);
            entity.ModifiedOn = DateTime.Now;
            oldCheckUp.Counter = entity.Counter;
            oldCheckUp.ArriveDate = entity.ArriveDate;
            oldCheckUp.LeaveDate = entity.LeaveDate;
            oldCheckUp.TotalCost = entity.TotalCost;
            oldCheckUp.TotalPoints = entity.TotalPoints;
            oldCheckUp.CarId = entity.CarId;
            return await _AutoCheckUpsContext.SaveChangesAsync();
        }
        public async Task<int> Delete(CheckUps check)
        {
            _AutoCheckUpsContext.CheckUps.Remove(check);
            return await _AutoCheckUpsContext.SaveChangesAsync();
        }
    }
}

