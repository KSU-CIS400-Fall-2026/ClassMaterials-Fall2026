using System;
using System.Collections.Generic;
using System.Text;

namespace EnumsInClassDemo
{
    /*
     * TrafficLightStatus demonstrates another situation where
     * an enum is a natural choice.
     *
     * A traffic light should only have one of a few known states:
     * Red, Green, or Yellow.
     *
     * If we used strings, a programmer could accidentally write
     * values such as:
     *
     * "red"
     * "RED"
     * "Reed"
     * "Stop"
     *
     * The compiler would accept all of those as strings even though
     * they may not represent the values our program expects.
     *
     * With an enum, we define the allowed choices explicitly.
     */
    public enum TrafficLightStatus
    {
        Red,
        Green,
        Yellow
    }
}
