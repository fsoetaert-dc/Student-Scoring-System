
using StudentScoringSystem.Api.Application.CreateStudent;
using StudentScoringSystem.Api.Application.StudentList;
using StudentScoringSystem.Api.Application.UpdateStudent;
using StudentScoringSystem.Api.Domain;
using StudentScoringSystem.Api.Storage;

namespace StudentScoringSystem.Api.Application;

public class StudentService(EfStudentRepository studentRepository)
{
    public async Task<IReadOnlyList<StudentNameId>> GetAllStudentsAsync()
    {
        var students = await studentRepository.GetAllStudentsAsync();
        return students;
    }

    public async Task<IReadOnlyList<StudentInfo>> GetAllStudentInfoAsync()
    {
        var studentInfo = await studentRepository.GetAllStudentInfoAsync();

        return studentInfo;
    }

        public async Task<List<Student>> GetByNameAsync(string studentName)
    {
        var students = await studentRepository.GetByNameAsync(studentName);
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

    public async Task<bool> DeleteStudentAsync(Guid id)
    {
        var result = await studentRepository.DeleteStudentAsync(id);
        return result;
    }

    public async Task<Student> UpdateStudentAsync(UpdateStudentRequest request)
    {
        var student = await studentRepository.FindByIdAsync(request.Id);

        if (student is null)
        {
            throw new Exception("Student not found");
        }

        student.StudentName = new StudentName(request.StudentName);
        student.DateOfBirth = request.DateOfBirth;
        student.Address = new Address(
            request.Street,
            request.HouseNumber,
            request.City,
            request.PostalCode,
            request.Country
        );

        return await studentRepository.UpdateStudentAsync(student);
    }



}

