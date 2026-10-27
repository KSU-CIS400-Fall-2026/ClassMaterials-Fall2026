using System.Collections.ObjectModel;
using System.Collections.Specialized;


// ================================================================
// COLLECTIONCHANGED DEMO
// ================================================================
//
// ObservableCollection<T> is a special collection that can notify
// other parts of our program whenever the collection itself changes.
//
// Examples of collection changes:
//
//      Add an item
//      Remove an item
//      Replace an item
//      Move an item
//      Clear the collection
//
// It does this through an event called CollectionChanged.
// ================================================================


// Create an ObservableCollection that stores strings.
ObservableCollection<string> equipment =
    new ObservableCollection<string>();


// At this point the collection exists, but it is empty.
Console.WriteLine("Collection created.");
Console.WriteLine($"Number of items: {equipment.Count}");


// ================================================================
// ADD AN ITEM BEFORE SUBSCRIBING TO THE EVENT
// ================================================================

equipment.Add("Laptop");


// Display the items currently in the collection.
Console.WriteLine("\nCurrent equipment:");

foreach (string item in equipment)
{
    Console.WriteLine(item);
}


// Notice:
//
// We added "Laptop" BEFORE subscribing to CollectionChanged.
//
// Therefore, our event handler did NOT run when Laptop was added.
//
// ObservableCollection raises the event, but nobody was listening yet.


// ================================================================
// SUBSCRIBE TO COLLECTIONCHANGED
// ================================================================
//
// CollectionChanged is an EVENT.
//
// EquipmentChange_Notification is our EVENT HANDLER.
//
// += means:
//
// "When CollectionChanged happens, call
//  EquipmentChange_Notification."
//
// We are registering/subscribing our method to the event.

equipment.CollectionChanged += EquipmentChange_Notification;


// From this point onward, changes to the collection will cause
// EquipmentChange_Notification to execute.


Console.WriteLine("\n--- Adding items ---");

equipment.Add("Furniture");
equipment.Add("Computers");
equipment.Add("Printers");


// Every Add() above causes CollectionChanged to fire.
//
// Conceptually:
//
// equipment.Add("Furniture")
//          ↓
// Collection changes
//          ↓
// CollectionChanged event fires
//          ↓
// EquipmentChange_Notification(...) executes


Console.WriteLine("\n--- Removing an item ---");

equipment.Remove("Laptop");


// Remove() also causes CollectionChanged to fire.
//
// However, the Action will now be:
//
// NotifyCollectionChangedAction.Remove


Console.WriteLine("\n--- Replacing an item ---");

// ObservableCollection also notifies us when an item at a
// particular index is replaced.
//
// Suppose the collection currently contains:
//
// Furniture
// Computers
// Printers
//
// Index 0 is Furniture.

equipment[0] = "Projector";


// This causes:
//
// NotifyCollectionChangedAction.Replace


Console.WriteLine("\n--- Moving an item ---");

// ObservableCollection provides a Move() method.
//
// Move(oldIndex, newIndex)
//
// Move the item at index 0 to index 2.

equipment.Move(0, 2);


// This causes:
//
// NotifyCollectionChangedAction.Move


Console.WriteLine("\n--- Clearing the collection ---");

equipment.Clear();


// Clear() removes everything.
//
// Interestingly, Clear() does NOT normally report each item
// individually as being removed.
//
// Instead, ObservableCollection reports:
//
// NotifyCollectionChangedAction.Reset


// ================================================================
// EVENT HANDLER
// ================================================================
//
// This method runs whenever the ObservableCollection changes.
//
// sender:
//      The object that raised the event.
//
// e:
//      Information describing HOW the collection changed.
//
// NotifyCollectionChangedEventArgs gives us useful properties:
//
//      e.Action
//      e.NewItems
//      e.OldItems
//      e.NewStartingIndex
//      e.OldStartingIndex
//
// ================================================================

void EquipmentChange_Notification(
    object? sender,
    NotifyCollectionChangedEventArgs e)
{
    Console.WriteLine();
    Console.WriteLine("COLLECTION CHANGED!");

    // e.Action tells us WHAT KIND of change occurred.
    Console.WriteLine($"Action: {e.Action}");


    // ============================================================
    // ADD
    // ============================================================

    if (e.Action == NotifyCollectionChangedAction.Add)
    {
        // NewItems contains the item or items that were added.
        //
        // Because we are adding one item at a time,
        // NewItems[0] gives us that item.

        string itemAdded = (string)e.NewItems![0]!;

        Console.WriteLine($"Item Added: {itemAdded}");

        // NewStartingIndex tells us where the new item was inserted.
        Console.WriteLine(
            $"Added at index: {e.NewStartingIndex}");
    }


    // ============================================================
    // REMOVE
    // ============================================================

    else if (e.Action == NotifyCollectionChangedAction.Remove)
    {
        // OldItems contains the item or items that were removed.

        string itemRemoved = (string)e.OldItems![0]!;

        Console.WriteLine($"Item Removed: {itemRemoved}");

        // OldStartingIndex tells us where the item used to be.
        Console.WriteLine(
            $"Removed from index: {e.OldStartingIndex}");
    }


    // ============================================================
    // REPLACE
    // ============================================================

    else if (e.Action == NotifyCollectionChangedAction.Replace)
    {
        // When an item is replaced:
        //
        // OldItems = what used to be there
        // NewItems = what replaced it

        string oldItem = (string)e.OldItems![0]!;
        string newItem = (string)e.NewItems![0]!;

        Console.WriteLine($"Old Item: {oldItem}");
        Console.WriteLine($"New Item: {newItem}");
    }


    // ============================================================
    // MOVE
    // ============================================================

    else if (e.Action == NotifyCollectionChangedAction.Move)
    {
        string movedItem = (string)e.NewItems![0]!;

        Console.WriteLine($"Item Moved: {movedItem}");

        Console.WriteLine(
            $"Old Index: {e.OldStartingIndex}");

        Console.WriteLine(
            $"New Index: {e.NewStartingIndex}");
    }


    // ============================================================
    // RESET
    // ============================================================

    else if (e.Action == NotifyCollectionChangedAction.Reset)
    {
        // Reset commonly occurs after Clear().
        //
        // It basically means:
        //
        // "The collection changed so significantly that you
        // should refresh your understanding of the collection."

        Console.WriteLine(
            "The collection was reset/cleared.");
    }
}