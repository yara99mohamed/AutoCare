using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models.Repository
{
    public class UsersRepoistory:IAutoRepository<User>
    {
        readonly AutoCareContext _AutoUserContext;
        public UsersRepoistory(AutoCareContext context)
        {
            _AutoUserContext = context;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _AutoUserContext.users.ToListAsync();
        }
        public async Task<User> Get(long? id)
        {
            return await _AutoUserContext.users.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<int> Add(User entity)
        {
            entity.CreateOn = DateTime.Now;
            entity.ModifiedOn = DateTime.Now;
            await _AutoUserContext.users.AddAsync(entity);
            return await _AutoUserContext.SaveChangesAsync();
        }
        public async Task<int> Update(long id, User entity)
        {
            var oldCheckUp = await Get(id);
            entity.ModifiedOn = DateTime.Now;
            oldCheckUp.FirstName = entity.FirstName;
            oldCheckUp.LastName = entity.LastName;
            oldCheckUp.Mobile = entity.Mobile;
            oldCheckUp.Password = entity.Password;
            oldCheckUp.NationalIdNumber = entity.NationalIdNumber;
            oldCheckUp.Email = entity.Email;
            oldCheckUp.Points = entity.Points;
            oldCheckUp.RolerId = entity.RolerId;
            return await _AutoUserContext.SaveChangesAsync();
        }
        public async Task<int> Delete(User user)
        {
            _AutoUserContext.users.Remove(user);
            return await _AutoUserContext.SaveChangesAsync();
        }
    }
}
