using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildBox : MonoBehaviour
{
    /*
     * this uses a raindrop for inspiration on how to create the box so that the box always lines up with the shelf
     * this is attached to a gameobject that falls and then collides with the shelf
     * on collision it creates a box centered across the shelf at the position of the falling object 
     * the created box has the name specified
    */
    public GameObject box; //the falling object
    public GameObject createdShape; //the created shape
    public float width; //the width of the box on the shelf
    private void OnCollisionEnter(Collision collision)
    {
        buildBox(collision.gameObject.GetComponent<DataForShelf>().height, collision.gameObject.GetComponent<DataForShelf>().depth,collision.gameObject); // gets the height depth and the shelf from the collision data.
    }
    public void buildBox(float height, float depth, GameObject parent) 
    {
       createdShape = Instantiate(box, this.transform.position, parent.transform.rotation, parent.transform); // create the box (with the shelf's rotation)
       createdShape.transform.localScale = new Vector3(depth, height, width); //Set the width with scale
       createdShape.transform.localPosition = new Vector3(0, createdShape.transform.localPosition.y + height / 2, createdShape.transform.localPosition.z); // Center the box
        createdShape.GetComponent<Item>().name= "Itemplaceholder"; //sets the name of the box
       Destroy(this.gameObject); //destroy this object (the "Raindrop" used only for positioning)
    } 
}
