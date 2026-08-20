using StudentScoringSystem.Api.Domain;

namespace StudentScoringSystem.Api.Storage;

public interface IStudentRepository
{
    Task<IReadOnlyList<Student>> GetAllAsync();
    Task<Student?> GetByNameAsync(string studentName);
    Task<Student> AddStudentAsync(Student student);
    Task<bool> DeleteStudentAsync(Guid id);
}