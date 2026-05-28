/*
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



var rankedStudents = students
    .OrderByDescending(s => s.GPA)
    .Select(s => new
    {
        s.Name,
        s.GPA
    });

Console.WriteLine();

Console.WriteLine("Ranked Students:");

foreach (var student in rankedStudents)
{
    Console.WriteLine($"{student.Name} - {student.GPA}");
}


decimal averageGpa = students.Average(s => s.GPA);

int strugglingStudents = students.Count(s => s.GPA < 2.0m);

bool hasProbationStudents = students.Any(s => s.GPA < 2.5m);

Student? topStudent = students.MaxBy(s => s.GPA);

Console.WriteLine();

Console.WriteLine($"Average GPA: {averageGpa:F2}");
Console.WriteLine($"Struggling Students: {strugglingStudents}");
Console.WriteLine($"Any Probation Students: {hasProbationStudents}");
Console.WriteLine($"Top Student: {topStudent?.Name}");


foreach (var student in students)
{
    string status = student.GPA switch
    {
        >= 3.5m => "Honors",
        >= 2.5m => "Good Standing",
        _ => "Academic Warning"
    };

    Console.WriteLine($"{student.Name}: {status}");
}


foreach (var student in students)
{
    string category = student switch
    {
        { GPA: >= 3.5m, Age: < 22 } => "Young Honors",
        { GPA: >= 3.0m } => "High Performer",
        _ => "Regular"
    };

    Console.WriteLine($"{student.Name}: {category}");
}



static void ValidateStudent(Student? student)
{
    if (student is null)
    {
        throw new ArgumentNullException(nameof(student));
    }

    Console.WriteLine($"Validated: {student.Name}");
}

ValidateStudent(students.First());

*/


//Session 3
using System.Diagnostics;

var sw = Stopwatch.StartNew();

async Task<Student> FetchStudentAsync(string id)
{
    Console.WriteLine($"Fetching {id}...");

    await Task.Delay(300);

    return new Student
    {
        Id = id,
        Name = $"Student-{id}",
        Age = 20,

        GPA = id switch
        {
            "S1" => 3.8m,
            "S2" => 2.4m,
            "S3" => 3.5m,
            "S4" => 1.9m,
            "S5" => 3.2m,
            _ => 2.5m
        }
    };
}

async Task<Course> FetchCourseAsync(string code)
{
    Console.WriteLine($"Fetching course {code}...");

    await Task.Delay(200);

    return new Course
    {
        Code = code,
        Title = $"Course-{code}",

        Capacity = code switch
        {
            "CRS-101" => 2,
            "CRS-201" => 30,
            "CRS-301" => 15,
            _ => 25
        }
    };
}

string[] studentIds = ["S1", "S2", "S3", "S4", "S5"];

string[] courseCodes =
[
    "CRS-101",
    "CRS-201",
    "CRS-301"
];

var studentTasks =
    studentIds.Select(id => FetchStudentAsync(id));

var courseTasks =
    courseCodes.Select(code => FetchCourseAsync(code));

Student[] students =
    await Task.WhenAll(studentTasks);

Course[] courses =
    await Task.WhenAll(courseTasks);

Console.WriteLine(
    $"\nLoaded {students.Length} students and {courses.Length} courses in {sw.ElapsedMilliseconds}ms"
);

foreach (var s in students)
{
    Console.WriteLine($"{s.Name} GPA: {s.GPA}");
}