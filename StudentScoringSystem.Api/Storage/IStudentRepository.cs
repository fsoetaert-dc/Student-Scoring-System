using StudentScoringSystem.Api.Application.StudentList;
using StudentScoringSystem.Api.Domain;

namespace StudentScoringSystem.Api.Storage;

public interface IStudentRepository
{
    Task<IReadOnlyList<StudentNameId>> GetAllStudentsAsync();
    Task<IReadOnlyList<Student>> GetAllStudentInfoAsync();
    Task<List<Student>> GetByNameAsync(string studentName);
    Task<Student> AddStudentAsync(Student student);
    Task<bool> DeleteStudentAsync(Guid id);
}