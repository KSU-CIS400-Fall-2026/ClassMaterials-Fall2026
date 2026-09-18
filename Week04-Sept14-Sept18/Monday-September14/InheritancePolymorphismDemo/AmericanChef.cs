using System;
using System.Collections.Generic;
using System.Text;

namespace InheritancePolymorphismDemo
{
    /*
     * AmericanChef INHERITS from Chef.
     *
     * The colon (:) establishes the inheritance relationship:
     *
     * AmericanChef : Chef
     *
     * We can read this as:
     *
     * "AmericanChef is a Chef."
     *
     * Because AmericanChef inherits from Chef, it receives the
     * accessible properties and methods defined by Chef.
     */
    public class AmericanChef : Chef
    {
        /*
         * Salary belongs specifically to AmericanChef in this demo.
         *
         * This demonstrates that a derived class can have everything
         * it inherits from the base class AND introduce additional
         * members of its own.
         */
        public decimal Salary { get; set; }


        /*
         * Constructor chaining
         *
         * AmericanChef needs:
         *
         * name
         * school
         * salary
         *
         * Name and School are responsibilities of the Chef base class.
         *
         * Instead of repeating the initialization logic here, we send
         * name and school to the Chef constructor using:
         *
         * base(name, school)
         *
         * The Chef constructor runs first and initializes the
         * inherited Name and School properties.
         *
         * We then initialize Salary, which belongs to AmericanChef.
         */
        public AmericanChef(
            string name,
            string school,
            decimal salary) : base(name, school)
        {
            Salary = salary;
        }


        /*
         * MakeBurger() exists only in AmericanChef.
         *
         * Chef does not define this method.
         *
         * This demonstrates that derived classes can introduce
         * specialized behaviors in addition to inherited behaviors.
         */
        public void MakeBurger()
        {
            Console.WriteLine("Can make American burger!");
        }


        /*
         * Chef declared MakePizza() as virtual.
         *
         * Therefore, AmericanChef can override it and provide a
         * more specialized implementation.
         *
         * We are saying:
         *
         * "An AmericanChef is still a Chef and can still make pizza,
         * but an AmericanChef makes pizza in a specialized way."
         */
        public override void MakePizza()
        {
            Console.WriteLine($"{Name} can make American Pepperoni pizza!");
        }
    }
}
