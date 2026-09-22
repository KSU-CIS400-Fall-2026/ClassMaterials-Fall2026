using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClassesInterfacesDemo
{
    /*
    * Animal is an ABSTRACT CLASS.
    *
    * An abstract class is designed to serve as a base class
    * for other related classes.
    *
    * We know that animals share common characteristics and behaviors,
    * but "Animal" itself is a general concept. In this program,
    * we want to create specific animals such as Lion and Cat.
    *
    * The abstract keyword also prevents us from creating an
    * Animal object directly.
    */
    public abstract class Animal
    {
        /*
         * Name is a regular property.
         *
         * Even though Animal is abstract, it can still contain
         * normal properties, fields, constructors, and methods.
         *
         * Classes that inherit from Animal also inherit this property.
         */
        public string Name { get; set; }


        /*
         * MakeSound() is an ABSTRACT METHOD.
         *
         * We know that every animal should be able to make a sound,
         * but the Animal class cannot provide one correct sound
         * for every possible animal.
         *
         * A lion roars.
         * A cat meows.
         * A dog barks.
         *
         * Therefore, Animal defines WHAT every derived animal
         * must be able to do, but leaves HOW it does it to
         * the derived class.
         *
         * Notice that an abstract method has no method body.
         */
        public abstract void MakeSound();


        /*
         * We could NOT write an abstract method like this:
         *
         * public abstract void MakeSound()
         * {
         *     Console.WriteLine($"{Name} makes sound...");
         * }
         *
         * An abstract method does not provide an implementation.
         * The implementation must come from a derived class.
         */
    }


    /*
     * Lion inherits from Animal.
     *
     * Lion IS-AN Animal.
     *
     * Because Animal declares MakeSound() as abstract,
     * Lion MUST provide an implementation of MakeSound().
     */
    public class Lion : Animal
    {
        /*
         * override provides Lion's implementation of the
         * abstract MakeSound() method inherited from Animal.
         */
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} Roarrrrrrss!!!!");
        }
    }


    /*
     * Cat also inherits from Animal.
     *
     * Cat receives the Name property from Animal and must also
     * provide its own implementation of MakeSound().
     */
    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} Mewwwwwwww!!!!");
        }
    }
}
