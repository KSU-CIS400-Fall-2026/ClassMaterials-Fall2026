
using EnumsInClassDemo;

/*
 * ENUMERATION DEMONSTRATION
 *
 * This program demonstrates how an enum can be used
 * with a regular C# class.
 *
 * AcademicStatus was defined separately inside our
 * EnumsFolder and is now being used as the type of the
 * Student.Status property.
 */


// Create a new Student object.
//
// The Student constructor expects two arguments:
//
// 1. A string representing the student's name.
// 2. An AcademicStatus value representing the student's status.
//
// Notice that we do NOT pass:
//
// "Incomplete"
//
// as an ordinary string.
//
// Instead, we use the AcademicStatus enum and select one
// of the predefined choices.
Student student1 = new Student("Doe", AcademicStatus.Incomplete);


// Display the student's original information.
//
// Because the student's current status is Incomplete,
// DisplayInfo() will display that enum value.
student1.DisplayInfo();


Console.WriteLine();


// We can also change the student's status later.
//
// Again, Status expects an AcademicStatus value.
// We therefore select another value from the enum.
//
// Typing:
//
// AcademicStatus.
//
// in Visual Studio will also allow IntelliSense to show
// the available enum members.
student1.Status = AcademicStatus.Fail;


// Display the student's information again.
//
// The student's status should now display "Fail".
student1.DisplayInfo();