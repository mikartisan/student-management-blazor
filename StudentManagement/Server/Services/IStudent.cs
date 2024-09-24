using StudentManagement.Shared.Models;

namespace StudentManagement.Server.Services
{
    public interface IStudent
    {
        Task<List<Student>> GetStudents();
        Task<ResponseService> AddStudent(Student student);
        Task<ResponseService> DeleteStudent(int id);
        Task<ResponseService> UpdateStudent(Student student);
    }
}
