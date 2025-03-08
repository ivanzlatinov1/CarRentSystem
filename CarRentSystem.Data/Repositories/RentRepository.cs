﻿using CarRentSystem.Data.Entities;
using CarRentSystem.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CarRentSystem.Data.Repositories
{
    public class RentRepository(ApplicationDbContext context) : IRentRepository
    {
        private readonly DbSet<Rent> _set = context.Set<Rent>();

        public async Task<ICollection<Rent>> GetAllAsync()
            => await _set.ToArrayAsync();

        public async Task<Rent?> GetByIdAsync(int rentId)
            => await _set.FindAsync(rentId);

        public async Task<string> RentCarAsync(int userId, int carId)
        {
            bool isCarRented = await _set
                .AnyAsync(r => r.CarId == carId && r.ReturnDate == null);

            if (isCarRented)
                return "Car is already rented.";

            var rent = new Rent
            {
                UserId = userId,
                CarId = carId,
                RentDate = DateTime.Now,
                ReturnDate = null
            };

            _set.Add(rent);
            await context.SaveChangesAsync();

            return "Car rented successfully.";
        }

        public async Task<string> ReturnCarAsync(int rentId)
        {
            Rent? rent = await this.GetByIdAsync(rentId);

            if (rent == null || rent.ReturnDate != null)
                return "Invalid rent or car already returned.";

            rent.ReturnDate = DateTime.Now;
            await context.SaveChangesAsync();

            return "Car returned successfully.";
        }

        public async Task UpdateAsync(Rent rent)
        {
            _set.Update(rent);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Rent rent)
        {
            _set.Remove(rent);
            await context.SaveChangesAsync();
        }
    }
}
