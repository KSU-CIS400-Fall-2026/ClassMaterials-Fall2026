using System;
using System.Collections.Generic;
using System.Text;

namespace InheritancePolymorphismDemo
{
    /*
    * ItalianChef is another derived class of Chef.
    *
    * This demonstrates that multiple classes can inherit from
    * the same base class.
    *
    *                 Chef
    *                /    \
    *       AmericanChef  ItalianChef
    *
    * Both specialized chefs share the common functionality
    * defined by Chef.
    */
    public class ItalianChef : Chef
    {
        /*
         * Chef does not have a parameterless constructor.
         *
         * Therefore, ItalianChef must provide the information
         * required by the Chef constructor.
         *
         * base(name, school) calls the constructor of Chef.
         */
        public ItalianChef(string name, string school)
            : base(name, school)
        {
            // Nothing additional is required here yet.
            //
            // ItalianChef currently relies entirely on the
            // properties and behaviors inherited from Chef.
        }
    }
}
