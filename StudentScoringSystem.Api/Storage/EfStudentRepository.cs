using StudentScoringSystem.Api.Domain;
using Microsoft.EntityFrameworkCore;
using StudentScoringSystem.Api.Application.StudentList;

namespace StudentScoringSystem.Api.Storage;

public class EfStudentRepository(AppDbContext dbContext)
{

    public async Task<IReadOnlyList<StudentNameId>> GetAllStudentsAsync()
    {
        return await dbContext.Students
            .Select(s => new StudentNameId
            {
                StudentName = s.StudentName.Value,
                Id = s.Id
            })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IReadOnlyList<StudentInfo>> GetAllStudentInfoAsync()
    {
        return await dbContext.Students
            .Select(s => new StudentInfo
            {
                Id = s.Id,
                StudentName = s.StudentName.Value,
                DateOfBirth = s.DateOfBirth,
                Address = s.Address
            })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Student>> GetByNameAsync(string studentName)
    {
        return await dbContext.Students
        .Where(s => s.StudentName.Value == studentName)
        .ToListAsync();
    }

    public async Task<Student> AddStudentAsync(Student student)
    {
        dbContext.Students.Add(student);
        await dbContext.SaveChangesAsync();
        return student;
    }

    public async Task<bool> DeleteStudentAsync(Guid id)
    {
        var student = await dbContext.Students.FindAsync(id);

        if (student is null)
        {
            return false;
        }

        dbContext.Students.Remove(student);
        await dbContext.SaveChangesAsync();
        return true;
    }
}