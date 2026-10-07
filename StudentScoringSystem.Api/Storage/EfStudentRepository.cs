using StudentScoringSystem.Api.Domain;
using Microsoft.EntityFrameworkCore;
using StudentScoringSystem.Api.Storage;
using StudentScoringSystem.Api.Application.StudentList;

namespace StudentScoringSystem.Api.Storage;

public class EfStudentRepository(AppDbContext dbContext) : IStudentRepository
{
    public async Task<IReadOnlyList<StudentNameId>> GetAllStudentsAsync()
    {
        return await dbContext.Students.AsNoTracking();
    }

    public async Task<IReadOnlyList<Student>> GetAllStudentInfoAsync()
    {
        return await dbContext.Students.AsNoTracking();
    }

    public async Task<List<Student>> GetByNameAsync(string studentName)
    {
        return await dbContext.Students.AsNoTracking();
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