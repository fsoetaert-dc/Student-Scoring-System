using StudentScoringSystem.Api.Application.CreateStudent;
using StudentScoringSystem.Api.Application.StudentList;
using StudentScoringSystem.Api.Domain;
using StudentScoringSystem.Api.Storage;

namespace StudentScoringSystem.Api.Application;

public class StudentService(IStudentRepository studentRepository)
{
    public async Task<IReadOnlyList<StudentInfo>> GetAllStudentInfo()
    {
        var students = await studentRepository.GetAllStudentInfoAsync();
        var studentInfo = students.Select(s => new StudentInfo
        {
            StudentName = s.StudentName.Value,
            DateOfBirth = s.DateOfBirth,
            Id = s.Id,
            Address = s.Address
        }).ToList();

        return studentInfo;
    }

    public async Task<IReadOnlyList<StudentNameId>> GetAllStudentsAsync()
    {
        var students = await studentRepository.GetAllStudentsAsync();
        return students;
    }

    public async Task<CreateStudentResponse> CreateStudent(CreateStudentRequest request)
    {

        var student = new Student()
        {
            StudentName = new StudentName(request.StudentName),
            DateOfBirth = request.DateOfBirth,
            Address = new Address(
                request.Street,
                request.HouseNumber,
                request.City,
                request.PostalCode,
                request.Country)
        };
        var savedStudent = await studentRepository.AddStudentAsync(student);
        

        return new CreateStudentResponse(
            savedStudent.StudentName.Value,
            savedStudent.DateOfBirth,
            savedStudent.Id,
            new AddressResponse(
                savedStudent.Address.Street,
                savedStudent.Address.HouseNumber.ToString(),
                savedStudent.Address.City,
                savedStudent.Address.PostalCode.ToString(),
                savedStudent.Address.Country
                )
            );
    }

    public async Task<List<Student>> GetByNameAsync(string studentName)
    {
        var students = await studentRepository.GetByNameAsync(studentName);
        return students;
    }

}

