using StudentScoringSystem.Api.Application.StudentList;
using StudentScoringSystem.Api.Domain;

namespace StudentScoringSystem.Api.Storage;

public class InMemoryStudentRepository : IStudentRepository
{
    private readonly List<Student> students = [ ];

    public Task<IReadOnlyList<StudentNameId>> GetAllStudentsAsync()
    {
        var studentNames = students.Select(s => new StudentNameId
        {
            StudentName = s.StudentName.Value,
            Id = s.Id
        })
        .ToList();
        return Task.FromResult<IReadOnlyList<StudentNameId>>(studentNames);
    }

    public Task<IReadOnlyList<Student>> GetAllStudentInfoAsync()
    {
        return Task.FromResult<IReadOnlyList<Student>>(students);
    }

    public Task<List<Student>> GetByNameAsync(string studentName)
    {
        var student = students.Where(book => book.StudentName.Value == studentName).ToList();
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