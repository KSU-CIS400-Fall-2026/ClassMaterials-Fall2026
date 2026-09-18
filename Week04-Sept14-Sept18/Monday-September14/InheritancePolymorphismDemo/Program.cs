using InheritancePolymorphismDemo;


/*
 * ============================================================
 * PART 1: WORKING WITH THE BASE CLASS
 * ============================================================
 *
 * Chef is the base class in our inheritance hierarchy.
 *
 * We can create a Chef object and use the properties and
 * methods defined directly inside Chef.
 */

Chef chef = new Chef("Friday", "CIA");

chef.MakeCookie();
Console.WriteLine();

chef.MakeBread();
Console.WriteLine();

chef.MakePizza();
Console.WriteLine();



/*
 * ============================================================
 * PART 2: WORKING WITH A DERIVED CLASS
 * ============================================================
 *
 * AmericanChef inherits from Chef.
 *
 * Therefore, an AmericanChef automatically receives accessible
 * members from Chef, including:
 *
 * Name
 * School
 * MakeCookie()
 * MakeBread()
 * MakePizza()
 *
 * AmericanChef can also introduce its own members such as
 * Salary and MakeBurger().
 */

Console.WriteLine("Coming from the American Chef");

AmericanChef americanChef = new AmericanChef("John", "ACA", 60000m);

americanChef.MakeCookie();
Console.WriteLine();

americanChef.MakeBread();
Console.WriteLine();

americanChef.MakePizza();
Console.WriteLine();

americanChef.MakeBurger();



/*
 * ============================================================
 * PART 3: POLYMORPHISM
 * ============================================================
 *
 * This line is very important:
 *
 * Chef chef2 = new AmericanChef(...);
 *
 * The variable type on the LEFT is Chef.
 *
 * The actual object created on the RIGHT is AmericanChef.
 *
 * This works because:
 *
 * AmericanChef IS-A Chef.
 *
 * Therefore, an AmericanChef object can be referenced using
 * a variable of its base type.
 */
Chef chef2 = new AmericanChef("Nuel", "ACA", 525m);


/*
 * POLYMORPHIC METHOD CALL
 *
 * chef2 is declared as Chef, but the actual object stored in
 * chef2 is an AmericanChef.
 *
 * MakePizza() was declared virtual in Chef and overridden
 * in AmericanChef.
 *
 * Therefore, C# uses the implementation belonging to the
 * actual object at runtime.
 *
 * The AmericanChef version of MakePizza() runs.
 */
chef2.MakePizza();

/*
 * One major benefit of inheritance and polymorphism is that
 * different derived objects can be treated through one
 * common base type.
 */

List<Chef> chefs = new List<Chef>();

chefs.Add(new AmericanChef("John", "ACA", 500m));
chefs.Add(new ItalianChef("Mario", "ICA"));


foreach (Chef chf in chefs)
{
    chf.MakePizza();
}

/*
 * Every object in the collection IS-A Chef.
 *
 * However, each object may actually be a different specialized
 * type at runtime.
 *
 * If those classes override MakePizza(), the appropriate
 * implementation can execute for each object.
 *
 * This is one of the major practical benefits of polymorphism:
 * we can write code against the common base type instead of
 * writing completely separate code for every derived type.
 */