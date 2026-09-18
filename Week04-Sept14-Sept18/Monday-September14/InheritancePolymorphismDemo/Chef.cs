using System;
using System.Collections.Generic;
using System.Text;

namespace InheritancePolymorphismDemo
{ /*
     * Chef is our BASE CLASS (also called the parent class).
     *
     * It contains properties and behaviors that are common to
     * different types of chefs.
     *
     * Instead of repeating Name, School, MakeCookie(), MakeBread(),
     * and MakePizza() in every specialized chef class, we define
     * the shared members once here.
     *
     * Other chef classes can then inherit from Chef.
     */
    public class Chef
    {
        // Public properties that can be inherited by derived classes.
        public string Name { get; set; }
        public string School { get; set; }


        /*
         * protected means this property is available inside Chef
         * AND inside classes that inherit from Chef.
         *
         * However, regular code outside these classes cannot access
         * it directly.
         *
         * This is useful when derived classes need access to a member,
         * but we do not want that member to be completely public.
         */
        protected string CookingMethod { get; set; }


        /*
         * Base-class constructor.
         *
         * Every Chef object needs a name and culinary school.
         * Derived classes can call this constructor using the
         * base(...) keyword.
         */
        public Chef(string name, string school)
        {
            Name = name;
            School = school;
        }


        /*
         * Regular inherited method.
         *
         * Derived classes such as AmericanChef and ItalianChef
         * automatically inherit this method.
         */
        public void MakeCookie()
        {
            Console.WriteLine($"{Name} can make cookies!");
        }


        // Another behavior shared by all chefs.
        public void MakeBread()
        {
            Console.WriteLine($"{Name} can make bread!");
        }


        /*
         * virtual is important for polymorphism.
         *
         * It tells C#:
         *
         * "Chef provides a default version of MakePizza(),
         * but a derived class is allowed to replace this behavior
         * with its own implementation."
         *
         * A derived class can do this using the override keyword.
         */
        public virtual void MakePizza()
        {
            Console.WriteLine($"{Name} can make pizza!");
        }
    }
}
