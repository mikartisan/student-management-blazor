using Blazored.Modal;
using CurrieTechnologies.Razor.SweetAlert2;
using StudentManagement.Shared.Models;
using System.Net.Http.Json;


namespace StudentManagement.Client.IStudentService
{

    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task<HttpResponseMessage> DeleteStudent(int id);
        Task<HttpResponseMessage> AddStudent(Student student);
        Task<HttpResponseMessage> EditStudent(Student student);
    }

    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> DeleteStudent(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Student?id={id}");
                return response;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public async Task<HttpResponseMessage> AddStudent(Student student)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"/api/Student/", student);
                return response;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<Student>> GetStudents()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Student>>("/api/Student");
                return response;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<HttpResponseMessage> EditStudent(Student student)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"/api/Student?id={student.StudentId}", student);
                return response;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
