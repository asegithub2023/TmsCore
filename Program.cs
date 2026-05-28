
string? region = null;

string? upperRegion = region?.ToUpper();
Console.WriteLine($"Region (conditional): {upperRegion}");

string displayRegion = region ?? "Unassigned";
Console.WriteLine($"Region (coalesced): {displayRegion}");

region ??= "Addis Ababa";
Console.WriteLine($"Region (assigned): {region}");

string studentName = "Abeba";
string studentId = "STU-001";
int enrollmentCount = 3;
decimal grantAmount = 1999.99m;
DateTime enrolledAt = DateTime.UtcNow;
string? campusRegion = null;

Console.WriteLine($"Student: {studentName} ({studentId})");
Console.WriteLine($"Courses: {enrollmentCount}");
Console.WriteLine($"Grant: {grantAmount:F2}");
Console.WriteLine($"Enrolled: {enrolledAt:yyyy-MM-dd}");
Console.WriteLine($"Campus: {campusRegion ?? "Not assigned"}");


// Legacy implementation
double grantPerStudent = 1999.99;
double totalAllocation = grantPerStudent * 100_000;

Console.WriteLine($"Total allocated (double): {totalAllocation:R}");

// Fixed implementation
decimal grantPerStudentDecimal = 1999.99m;
decimal totalAllocationDecimal = grantPerStudentDecimal * 100_000m;

Console.WriteLine($"Total allocated (decimal): {totalAllocationDecimal}");
Console.WriteLine($"Total allocated (formatted): {totalAllocationDecimal:F2}");



var enrollment = new EnrollmentRecord(
    "STU-001",
    "CS-401",
    DateTime.UtcNow
);

Console.WriteLine(enrollment);

var corrected = enrollment with { CourseCode = "CS-402" };

Console.WriteLine(corrected);

var duplicate = new EnrollmentRecord(
    "STU-001",
    "CS-401",
    enrollment.EnrolledAt
);

Console.WriteLine($"Same data? {enrollment == duplicate}");



var course = new Course
{
    Code = "CS-401",
    Title = "Advanced C#",
    Capacity = 30
};

Console.WriteLine($"Course: {course.Title} (Capacity: {course.Capacity})");

try
{
    course.Capacity = -5;
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}

try
{
    course.Title = "";
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}


var s = new Student
{
    Id = "S1",
    Name = "Abeba",
    Age = 20,
    GPA = 3.8m
};

Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");


void PrintGradeReport(IEnumerable<IGradable> assessments)
{
    Console.WriteLine("--- Grade Report ---");

    foreach (var item in assessments)
    {
        Console.WriteLine($"{item.Title}: {item.CalculateGrade():F2}%");
    }
}

IGradable[] cohortAssessments =
[
    new Quiz
    {
        Title = "C# Basics",
        CorrectAnswers = 18,
        TotalQuestions = 20
    },

    new LabAssignment
    {
        Title = "Registration API",
        FunctionalityScore = 90m,
        CodeQualityScore = 85m
    }
];

PrintGradeReport(cohortAssessments);


//session2

List<string> backendCourses =
[
    "C#",
    "ASP.NET Core",
    "SQL Server"
];

List<string> frontendCourses =
[
    "Angular",
    "HTML",
    "CSS"
];

Console.WriteLine("Backend Courses:");

foreach (var courseName in backendCourses)
{
    Console.WriteLine(courseName);
}

Console.WriteLine();

Console.WriteLine("Frontend Courses:");

foreach (var courseName in frontendCourses)
{
    Console.WriteLine(courseName);
}





string[] allCourses =
[
    ..backendCourses,
    ..frontendCourses,
    "Capstone Project"
];

Console.WriteLine();

Console.WriteLine("All Courses:");

foreach (var courses in allCourses)
{
    Console.WriteLine(courses);
}



List<Student> students =
[
    new()
    {
        Id = "S1",
        Name = "Abeba",
        GPA = 3.8m,
        Age = 21
    },

    new()
    {
        Id = "S2",
        Name = "Hana",
        GPA = 2.7m,
        Age = 20
    },

    new()
    {
        Id = "S3",
        Name = "Dawit",
        GPA = 3.2m,
        Age = 23
    },

    new()
    {
        Id = "S4",
        Name = "Kebede",
        GPA = 1.9m,
        Age = 25
    }
];


var honorsStudents = students
    .Where(s => s.GPA >= 3.0m);

Console.WriteLine();

Console.WriteLine("Honors Students:");

foreach (var student in honorsStudents)
{
    Console.WriteLine($"{student.Name} - {student.GPA}");
}