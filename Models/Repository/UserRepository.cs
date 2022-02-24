using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models.Repository
{
    public class UserRepository : IAutoRepository<User>
    {
      readonly AutoCareContext _autoCareContext;
      public  UserRepository (AutoCareContext context)
        {
            _autoCareContext = context;
        }
       public async Task<IEnumerable<User>> GetAll()
        {
            return await _autoCareContext.Users.ToListAsync(); 
        }
        public async Task<User> Get(long? id)
        {
            return await _autoCareContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<int> Add(User entity)
        {
            await  _autoCareContext.Users.AddAsync(entity);
            return await _autoCareContext.SaveChangesAsync();
        }
        public async Task<int> Update(long id, User entity)
        {
            var oldUser = await Get(id);
            oldUser.FirstName = entity.FirstName;
            oldUser.LastName = entity.LastName;
            oldUser.Mobile = entity.Mobile;
            oldUser.NationalIdNumber = entity.NationalIdNumber;
            oldUser.Password = entity.Password;
            oldUser.Points = entity.Points;
            oldUser.address = entity.address;
            oldUser.Email = entity.Email;
            oldUser.address = entity.address;
            return await _autoCareContext.SaveChangesAsync();

        }
        public async Task<int> Delete(User user)
        {
            _autoCareContext.Users.Remove(user);
            return await _autoCareContext.SaveChangesAsync();
        }         
    }
}
