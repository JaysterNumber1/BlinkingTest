using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public string names;
    public DateTime expDate;
    public string tags;
    public int quantity;

    public void Start()
    {
        this.name = names;
    }

    //Used when removing an item from the database
    public void Remove(int amount)
    {
        quantity -= amount;
        Debug.Log("Removed " + amount + ", " + quantity + " remaining");

    }

    //Used when adding an item to the database
    public void Add(int amount) 
    {
        quantity += amount;
        Debug.Log("Added " + amount + ", " + quantity + " remaining");
    }

    //Check how many items are in the database
    public void Stock()
    {
        Debug.Log("There are "+quantity+" of "+names+" left!");
    }



 
}
