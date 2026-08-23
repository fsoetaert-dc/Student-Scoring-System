using StudentScoringSystem.Api.Domain;

namespace StudentScoringSystem.Api.Storage;

public class InMemoryStudentRepository : IStudentRepository
{
    private readonly List<Student> students = [ ];

    public Task<IReadOnlyList<Student>> GetAllAsync()
    {
        return Task.FromResult<IReadOnlyList<Student>>(students);
    }

    public Task<Student?> GetByNameAsync(string studentName)
    {
        var student = students.FirstOrDefault(book => book.StudentName.Value == studentName);
        return Task.FromResult(student);
    }

    public Task<Student> AddStudentAsync(Student student)
    {
        students.Add(student);
        return Task.FromResult(student);
    }

    public Task<bool> DeleteStudentAsync(Guid id)
    {
        var student = students.FirstOrDefault(student => student.Id == id);

        if (student is null)
        {
            return Task.FromResult(false);
        }

        students.Remove(student);
        return Task.FromResult(true);
    }
}