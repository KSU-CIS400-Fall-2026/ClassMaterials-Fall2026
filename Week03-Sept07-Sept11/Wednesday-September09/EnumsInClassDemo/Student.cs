using System;
using System.Collections.Generic;
using System.Text;

namespace EnumsInClassDemo
{
    /*
     * The Student class demonstrates how an enum can be used
     * as part of a regular C# class.
     *
     * Notice that we are still using concepts we learned earlier:
     *
     * - private fields
     * - properties
     * - encapsulation
     * - validation
     * - constructors
     * - methods
     *
     * The new concept is that one of our properties now uses
     * an enum instead of a string.
     */

    public class Student
    {
        // Private field that stores the student's name.
        // Because it is private, code outside this class cannot
        // directly change the field.
        private string _name;


        /*
         * This field stores the student's academic status.
         *
         * Notice that its type is NOT string.
         *
         * AcademicStatus is the enum that we created inside
         * the EnumsFolder.
         *
         * Because the field has type AcademicStatus, it is intended
         * to hold one of the values defined by that enum, such as:
         *
         * AcademicStatus.Pass
         * AcademicStatus.Fail
         * AcademicStatus.Incomplete
         */
        private AcademicStatus _status;


        /*
         * Name provides controlled access to the private _name field.
         *
         * The getter returns the current name.
         *
         * The setter performs validation before changing _name.
         * A null, empty, or whitespace-only name will not be accepted.
         */
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
            }
        }


        /*
         * Status is an AcademicStatus property.
         *
         * This is an important difference from declaring:
         *
         * public string Status
         *
         * A string would allow almost any text to be assigned.
         *
         * By using AcademicStatus as the property type, we communicate
         * that the property should use the predefined academic states
         * from our enum.
         */
        public AcademicStatus Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }


        /*
         * Constructor
         *
         * When a Student object is created, the caller provides:
         *
         * 1. The student's name
         * 2. The student's AcademicStatus
         *
         * Notice that the second parameter is AcademicStatus,
         * not string.
         *
         * Example:
         *
         * new Student("Doe", AcademicStatus.Pass);
         *
         * We use the properties inside the constructor rather than
         * assigning directly to the fields. This allows the property
         * logic, such as Name validation, to still be used.
         */
        public Student(string name, AcademicStatus status)
        {
            Name = name;
            Status = status;
        }


        /*
         * DisplayInfo() displays the current state of the Student.
         *
         * When an enum value is included in string interpolation,
         * C# displays the name of the enum member.
         *
         * For example:
         *
         * AcademicStatus.Fail
         *
         * will appear as:
         *
         * Fail
         */
        public void DisplayInfo()
        {
            Console.WriteLine($"Student Name: {Name}");
            Console.WriteLine($"Student Status: {Status}");
        }
    }
}
