using Final_Santa.Contexts;
using Final_Santa.Models.Entities;
using Final_Santa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Final_Santa.Services
{
    internal class ErrandService
    {

        private static DataContext _context = new DataContext();

        public static async Task SaveAsync(ErrandModel model)
        {
            var _errand = new Errand
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                ErrandDescription = model.ErrandDescription,
                ErrandDate = model.ErrandDate,
                ErrandStatus = model.ErrandStatus,
                CustomerId = model.CustomerId

            };

            var _customer = await _context.Customers.FirstOrDefaultAsync(x => x.FirstName == model.FirstName && x.LastName == model.LastName && x.Email == model.Email && x.PhoneNumber == model.PhoneNumber);
            if (_customer != null)
                _errand.CustomerId = _customer.Id;
            else
                _errand.Customer = new Customer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,

                };

            _context.Add(_errand);
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<ErrandModel>> GetAllAsync()
        {
            var _errands = new List<ErrandModel>();

            foreach (var _errand in await _context.Errands.Include(x => x.Customer).ToListAsync())
                _errands.Add(new ErrandModel
                {
                    Title = _errand.Title,
                    ErrandDescription = _errand.ErrandDescription,
                    ErrandDate = _errand.ErrandDate,
                    ErrandStatus = _errand.ErrandStatus,
                    Id = _errand.Id,
                    FirstName = _errand.Customer.FirstName,
                    LastName = _errand.Customer.LastName,
                    Email = _errand.Customer.Email,
                    PhoneNumber = _errand.Customer.PhoneNumber,

                });

            return _errands;
        }


        public static async Task<ErrandModel> GetAsync(string title)
        {
            var _errand = await _context.Errands.Include(x => x.Customer).FirstOrDefaultAsync(x => x.Title == title);
            if (_errand != null)
                return new ErrandModel
                {
                    Title = _errand.Title,
                    ErrandDescription = _errand.ErrandDescription,
                    ErrandDate = _errand.ErrandDate,
                    ErrandStatus = _errand.ErrandStatus,
                    Id = _errand.Id,
                    FirstName = _errand.Customer.FirstName,
                    LastName = _errand.Customer.LastName,
                    Email = _errand.Customer.Email,
                    PhoneNumber = _errand.Customer.PhoneNumber,

                };

            else
                return null!;
        }

        public static async Task UpdateAsync(ErrandModel model)
        {
            var _errand = await _context.Errands.Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == model.Id);
            if (_errand != null)
            {
                if (!string.IsNullOrEmpty(model.FirstName) || !string.IsNullOrEmpty(model.LastName) || !string.IsNullOrEmpty(model.Email) || !string.IsNullOrEmpty(model.PhoneNumber))
                {
                    var _customer = await _context.Customers.FirstOrDefaultAsync(x => x.FirstName == model.FirstName && x.LastName == model.LastName && x.Email == model.Email && x.PhoneNumber == model.PhoneNumber);
                    if (_customer != null)
                        _errand.CustomerId = _customer.Id;
                    else
                    {
                        var customer = new Customer
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Email = model.Email,
                            PhoneNumber = model.PhoneNumber,

                        };

                        _context.Add(customer);
                        await _context.SaveChangesAsync();
                        _errand.CustomerId = customer.Id;
                    }

                }

                if (!string.IsNullOrEmpty(model.ErrandDescription))
                    _errand.ErrandDescription = model.ErrandDescription;
                _errand.ErrandStatus = model.ErrandStatus;


                _context.Update(_errand);
                await _context.SaveChangesAsync();

            }
        }

        public static async Task DeleteAsync(string title)
        {
            var errand = await _context.Errands.Include(x => x.Customer).FirstOrDefaultAsync(x => x.Title == title);
            if (errand != null)
            {
                _context.Remove(errand);
                await _context.SaveChangesAsync();
            }
        }
    }
}
