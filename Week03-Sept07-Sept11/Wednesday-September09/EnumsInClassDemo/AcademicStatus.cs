using System;
using System.Collections.Generic;
using System.Text;

namespace EnumsInClassDemo
{
    /*
     * AcademicStatus is an enum.
     *
     * An enum is useful when a value should come from a small,
     * predefined set of choices.
     *
     * Instead of storing a student's academic status as a string,
     * such as "Pass", "Fail", or "Incomplete", we define the valid
     * choices once inside this enum.
     *
     * This helps prevent spelling mistakes and inconsistent values
     * that could occur when using ordinary strings.
     *
     * Example:
     *
     * AcademicStatus.Pass
     * AcademicStatus.Fail
     * AcademicStatus.Incomplete
     *
     * AcademicStatus also becomes a real C# type that we can use
     * for fields, properties, parameters, and variables.
     */
    public enum AcademicStatus
    {
        Pass,
        Fail,
        Incomplete
    }
}
