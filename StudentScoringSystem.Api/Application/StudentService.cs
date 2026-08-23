using StudentScoringSystem.Api.Application.StudentList;
using StudentScoringSystem.Api.Storage;

namespace StudentScoringSystem.Api.Application;

public class StudentService(IStudentRepository studentRepository)
{
    public async Task<IReadOnlyList<StudentInfo>> GetAllStudents()
    {
        var students = await studentRepository.GetAllAsync();
        var studentInfoSummary = students.Select(s => new StudentInfo
        {
            StudentName = s.StudentName.Value,
            Age = s.Age,
            DateOfBirth = s.DateOfBirth,
            Id = s.Id,
            Address = s.Address.City
        }).ToList();

        return studentInfoSummary;
    }
}

