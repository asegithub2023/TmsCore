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