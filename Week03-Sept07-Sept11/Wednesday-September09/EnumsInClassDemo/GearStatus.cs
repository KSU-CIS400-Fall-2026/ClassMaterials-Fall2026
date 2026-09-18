using System;
using System.Collections.Generic;
using System.Text;

namespace EnumsInClassDemo
{
    /*
     * GearStatus is another example of an enum.
     *
     * A vehicle's gear should normally be one of a known set
     * of possible states. We therefore do not need an unrestricted
     * string to represent the gear.
     *
     * Using an enum clearly communicates which values are allowed.
     *
     * For example:
     *
     * GearStatus.Park
     * GearStatus.Reverse
     * GearStatus.Drive
     * GearStatus.Neutral
     *
     * This also allows Visual Studio IntelliSense to show us the
     * available options when we type "GearStatus."
     */
    public enum GearStatus
    {
        Park,
        Reverse,
        Drive,
        Neutral
    }
}
