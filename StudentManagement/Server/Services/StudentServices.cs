using Microsoft.EntityFrameworkCore;
using StudentManagement.Server.Data;
using StudentManagement.Shared.Models;

namespace StudentManagement.Server.Services
{
    public class StudentServices : IStudent
    {
        private readonly SchoolDbContext _context;

        public StudentServices(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseService> AddStudent(Student student)
        {
            try 
            {
                var data = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == student.StudentId);
                if (data != null)
                {
                    return new ResponseService { isSuccess = false, Message = "Student already exists." };
                }

                _context.Students.Add(student);
                var isSuccess = await _context.SaveChangesAsync();
                if (isSuccess > 0) {
                    return new ResponseService { isSuccess = true, Message = "Student added successfully" };
                }

                return new ResponseService { isSuccess = false, Message = "Something went wrong." };
            }
            catch (Exception e)
            {
                return new ResponseService { isSuccess = false, Message = e.Message };
            }
        }

        public async Task<ResponseService> DeleteStudent(int id)
        {
            try
            {
                var data = await _context.Students.Where(s => s.StudentId == id).FirstOrDefaultAsync();
                if(data == null)
                {
                    return new ResponseService { isSuccess = false, Message = "Student not found." };
                }
                _context.Students.Remove(data);
                var isSuccess = await _context.SaveChangesAsync();
                if (isSuccess > 0)
                {
                    return new ResponseService { isSuccess = true, Message = "Student deleted successfully" };
                }

                return new ResponseService { isSuccess = false, Message = "Something went wrong." };

            }
            catch (Exception e)
            {
                return new ResponseService { isSuccess = false, Message = e.Message };
            }
        }

        public async Task<List<Student>> GetStudents()
        {
            try
            {
                var data = await _context.Students.ToListAsync();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ResponseService> UpdateStudent(Student student)
        {
            try
            {
                var data = await _context.Students.Where(s => s.StudentId == student.StudentId).FirstOrDefaultAsync();
                if (data == null)
                {
                    return new ResponseService { isSuccess = false, Message = "Student not found." };
                }

                data.FirstName = student.FirstName;
                data.LastName = student.LastName;
                data.Address = student.Address; 
                data.ContactNo = student.ContactNo;

                _context.Students.Update(data);
                var isSuccess = await _context.SaveChangesAsync();
                if (isSuccess > 0)
                {
                    return new ResponseService { isSuccess = true, Message = "Student updated successfully" };
                }

                return new ResponseService { isSuccess = false, Message = "Something went wrong." };
            }
            catch (Exception e)
            {
                return new ResponseService { isSuccess = false, Message = e.Message };
            }
        }
    }
}
