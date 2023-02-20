using Azure.Core;
using EC05_C_sharp_EntityFrameworkCore.Contexts;
using EC05_C_sharp_EntityFrameworkCore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_EntityFrameworkCore.Services
{
    internal class EmployeeService
    {
        DataContext _context = new();

        public async Task<EmployeeEntity> SaveAsync(EmployeeEntity employeeEntity)
        {
            _context.Add(employeeEntity);
            await _context.SaveChangesAsync();

            return employeeEntity;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetAllAync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeeEntity> GetAsync(Func<EmployeeEntity, bool> predicate)
        {
            var _emplyeeEntity = await _context.Employees.FindAsync(predicate);
            if (_emplyeeEntity != null)
            {
                return _emplyeeEntity;
            }
            return null!;
        }

        public async Task<EmployeeEntity> UpdateAsync(EmployeeEntity employeeEntity)
        {
            _context.Entry(employeeEntity).State= EntityState.Modified;
            await _context.SaveChangesAsync();


            return employeeEntity;
        }


        public async Task<EmployeeEntity> DeleteAsync(Func<EmployeeEntity, bool> predicate)
        {
            var _employeeEntity = await _context.Employees.FindAsync(predicate);
            if (_employeeEntity != null)
            {
                _context.Remove(_employeeEntity);
                await _context.SaveChangesAsync();
            }
        }
    }

}
