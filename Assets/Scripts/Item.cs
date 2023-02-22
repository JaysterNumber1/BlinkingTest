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


    public void Remove(int amount)
    {
        quantity -= amount;
        Debug.Log("Removed " + amount + ", " + quantity + " remaining");

    }
    public void Add(int amount) 
    {
        quantity += amount;
        Debug.Log("Added " + amount + ", " + quantity + " remaining");
    }
    public void Stock()
    {
        Debug.Log("There are "+quantity+" of "+names+" left!");
    }
    public void Locate(string name)
    {
        Debug.Log("Here you go!");
    }
}
