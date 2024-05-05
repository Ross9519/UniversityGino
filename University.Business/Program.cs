using University.DataAccess;
using University.DataAccess.Models;
using University.DataAccess.Repositories;

using UniversityContext context = new();

var subjectRepository = new SubjectRepository(context);
var officeStaffRepository = new OfficeStaffRepository(context);
var professorRepository = new ProfessorRepository(context);
var studentRepository = new StudentRepository(context);
var studyPlanRepository = new StudyPlanRepository(context);
var examRepository = new ExamRepository(context);


var items =  await subjectRepository.GetAllAsync();
foreach (var item in items)
    Console.WriteLine($"subject => {item}");

Console.WriteLine();

Console.WriteLine($"professor => {await professorRepository.GetByIdAsync(2)}");
var student = await studentRepository.GetByIdAsync(2);
Console.WriteLine($"student => {student}");
Console.WriteLine($"office staff => {await officeStaffRepository.GetByIdAsync(2)}");
Console.WriteLine($"study plan => {await studyPlanRepository.GetByIdAsync(2, 3)}");
Console.WriteLine($"exam => {await examRepository.GetByIdAsync(2,2,3)}");

Console.WriteLine();

if (student is not null)
{
    string ogFirstName = student.FirstName;
    string ogLastName = student.LastName;
    student.FirstName = "Pippo";
    student.LastName = "Pluto";
    await studentRepository.UpdateAsync(student);
    Console.WriteLine($"student modified => {await studentRepository.GetByIdAsync(2)}");

    student.FirstName = ogFirstName;
    student.LastName = ogLastName;
    await studentRepository.UpdateAsync(student);
    Console.WriteLine($"student with og name => {await studentRepository.GetByIdAsync(2)}");
}

Console.WriteLine();

var newStudyPlan = new StudyPlan()
{
    StudentId = 4,
    SubjectId = 5
};

await studyPlanRepository.InsertAsync(newStudyPlan);
Console.WriteLine($"student with id = 4 => {await studentRepository.GetByIdAsync(4)}");
Console.WriteLine($"subject with id = 5 => {await subjectRepository.GetByIdAsync(5)}");
var studyPlan = (await studyPlanRepository.GetAllAsync())[^1];
Console.WriteLine($"study plane created => {studyPlan}");
await studyPlanRepository.DeleteAsync(studyPlan);

Console.WriteLine();

Console.WriteLine($"office staff before => Active? {(await officeStaffRepository.GetByIdAsync(2))?.Active}");
await officeStaffRepository.DeleteByIdAsync(2);
var officeStaff = await officeStaffRepository.GetByIdAsync(2);
Console.WriteLine($"office staff after => Active? {officeStaff?.Active}");
if (officeStaff is not null)
{
    officeStaff.Active = true;
    await officeStaffRepository.UpdateAsync(officeStaff);
}