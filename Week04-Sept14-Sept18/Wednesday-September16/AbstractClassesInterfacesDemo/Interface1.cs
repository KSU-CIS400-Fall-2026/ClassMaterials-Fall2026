using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClassesInterfacesDemo
{
    /*
     * IPrey is an INTERFACE.
     *
     * An interface describes a capability or contract.
     *
     * In this example, anything that is considered prey
     * must provide a Flee() behavior.
     *
     * The interface tells implementing classes WHAT they
     * must be able to do.
     */
    public interface IPrey
    {
        void Flee();
    }


    /*
     * IPredator represents another capability.
     *
     * Anything that implements IPredator must provide
     * an Attack() method.
     */
    public interface IPredator
    {
        void Attack();
    }


    /*
     * Rabbit implements the IPrey interface.
     *
     * We can read:
     *
     * Rabbit : IPrey
     *
     * as:
     *
     * "Rabbit can behave as prey."
     *
     * Because Rabbit agrees to the IPrey contract,
     * it must implement Flee().
     */
    public class Rabbit : IPrey
    {
        public void Flee()
        {
            Console.WriteLine("The Rabbit is running away....");
        }
    }


    /*
     * Hawk implements IPredator.
     *
     * Therefore, Hawk must provide the Attack() behavior
     * required by the IPredator interface.
     */
    public class Hawk : IPredator
    {
        public void Attack()
        {
            Console.WriteLine("The Hawk pounces on the prey...");
        }
    }


    /*
     * Fish demonstrates an especially important feature
     * of interfaces.
     *
     * A class can implement MORE THAN ONE interface.
     *
     * Fish is both:
     *
     * IPrey
     * AND
     * IPredator
     *
     * Therefore, Fish must satisfy both contracts.
     */
    public class Fish : IPrey, IPredator
    {
        /*
         * Required by IPrey.
         */
        public void Flee()
        {
            Console.WriteLine("The Fish swims away from the predator...");
        }


        /*
         * Required by IPredator.
         */
        public void Attack()
        {
            Console.WriteLine("The Fish attacks smaller prey...");
        }
    }
}
