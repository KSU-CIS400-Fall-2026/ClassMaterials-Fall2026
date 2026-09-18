using AbstractClassesInterfacesDemo;


/*
 * ============================================================
 * ABSTRACT CLASS DEMONSTRATION
 * ============================================================
 *
 * Animal is an abstract class.
 *
 * Therefore, we CANNOT directly create an Animal object.
 *
 * The following line would cause a compiler error:
 */

Animal animal = new Animal();


/*
 * Why?
 *
 * Animal represents the general idea of an animal, but it does
 * not provide an implementation for MakeSound().
 *
 * Instead, we create objects from concrete derived classes
 * such as Lion and Cat.
 */


/*
 * ============================================================
 * POLYMORPHISM WITH AN ABSTRACT BASE CLASS
 * ============================================================
 *
 * The variable type is Animal.
 *
 * The actual object being created is Lion.
 *
 * This is allowed because:
 *
 * Lion IS-AN Animal.
 */
Animal lion = new Lion();


// Name is inherited from the Animal base class.
lion.Name = "Simba";


/*
 * MakeSound() was declared abstract in Animal and implemented
 * by Lion.
 *
 * Although the variable is declared as Animal, the actual object
 * is a Lion, so Lion's implementation executes.
 */
lion.MakeSound();



Console.WriteLine();


/*
 * We can do exactly the same thing with Cat.
 *
 * Cat IS-AN Animal, so a Cat object can also be referenced
 * using an Animal variable.
 */
Animal cat = new Cat();

cat.Name = "Cattyyy";


/*
 * The actual object is a Cat, so Cat's implementation of
 * MakeSound() executes.
 */
cat.MakeSound();


/*
 * ============================================================
 * INTERFACE DEMONSTRATION
 * ============================================================
 */

// Rabbit implements IPrey.
// Therefore, Rabbit provides Flee().

Rabbit rabbit = new Rabbit();
rabbit.Flee();


//Hawk implements IPredator.
//Therefore, Hawk provides Attack().

Hawk hawk = new Hawk();
hawk.Attack();



/*
 * Fish implements BOTH interfaces.
 *
 * Therefore, the same Fish object has both capabilities:
 *
 * Flee()
 * Attack()
 */

Fish fish = new Fish();

fish.Flee();
fish.Attack();


/*
 * ============================================================
 * INTERFACE POLYMORPHISM
 * ============================================================
 *
 * Just as a derived object can be referenced through its
 * base-class type, an object can also be referenced through
 * an interface that it implements.
 */


IPrey prey = new Rabbit();
prey.Flee();


IPredator predator = new Hawk();
predator.Attack();


/*
 * Fish implements both interfaces, so the same Fish object
 * can be viewed through either interface type.
 */

IPrey fishAsPrey = new Fish();
fishAsPrey.Flee();


IPredator fishAsPredator = new Fish();
fishAsPredator.Attack();