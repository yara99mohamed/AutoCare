using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoCare.Models.Repository
{
    public class CarRepository : IAutoRepository<Car>
    {
        readonly AutoCareContext _AutoCarContext;
        public CarRepository(AutoCareContext context)
        {
            _AutoCarContext = context;
        }
        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _AutoCarContext.Cars.Include(x => x.type).Include(y=>y.user).OrderByDescending(n=>n.UserId).ToListAsync();
        }
        public async Task<Car> Get(long? id)
        {
            return await _AutoCarContext.Cars.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<int> Add(Car car)
        {
                car.CreateOn = DateTime.Now;
                car.ModifiedOn = DateTime.Now;
            if (await _AutoCarContext.Cars.AnyAsync(c => c.CarLetter == car.CarLetter) && await _AutoCarContext.Cars.AnyAsync(t => t.CarNumber == car.CarNumber))
            {
                return -1 ;
            }
            //delete Value of IsActive
            await _AutoCarContext.Cars.AddAsync(car);          
            return await _AutoCarContext.SaveChangesAsync();               
        }
        public async Task<int> Update(long id, Car entity)
        {
            
            var oldcar = await Get(id);
            if (await _AutoCarContext.Cars.AnyAsync(c => c.CarLetter == entity.CarLetter) && await _AutoCarContext.Cars.AnyAsync(t => t.CarNumber == entity.CarNumber) && await _AutoCarContext.Cars.AnyAsync(c => c.UserId != entity.UserId))
            {
                oldcar.ModifiedOn = DateTime.Now;
                oldcar.CarLetter = entity.CarLetter;
                oldcar.CarModel = entity.CarModel;
                oldcar.CarNumber = entity.CarNumber;
                oldcar.TypeId = entity.TypeId;
                oldcar.UserId = entity.UserId;
                return await _AutoCarContext.SaveChangesAsync();
            }
            if (await _AutoCarContext.Cars.AnyAsync(c => c.CarLetter == entity.CarLetter) && await _AutoCarContext.Cars.AnyAsync(t => t.CarNumber == entity.CarNumber))
            {
                return -1;
            }          

            oldcar.ModifiedOn = DateTime.Now;
            oldcar.CarLetter = entity.CarLetter;
            oldcar.CarModel = entity.CarModel;
            oldcar.CarNumber = entity.CarNumber;
            oldcar.TypeId = entity.TypeId;
            oldcar.UserId = entity.UserId;
            return await _AutoCarContext.SaveChangesAsync();
        }
        public async Task<int> Delete(Car car)
        {
            _AutoCarContext.Cars.Remove(car);
            return await _AutoCarContext.SaveChangesAsync();
        }
    }
}
