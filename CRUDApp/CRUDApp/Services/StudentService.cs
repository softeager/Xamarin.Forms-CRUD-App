using CRUDApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Services
{
    public class StudentService
    {

        private DatabaseContext getContext()
        {
            return new DatabaseContext();
        }

        public async Task<List<StudentModel>> GetAllStudents()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Students.ToListAsync();
            return res;
        }

        public async Task<int> UpdateStudent(StudentModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Students.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

        public int InsertStudent(StudentModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Students.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        public int DeleteStudent(StudentModel obj)
        {

            var _dbContext = getContext();
            _dbContext.Students.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
    }
}
