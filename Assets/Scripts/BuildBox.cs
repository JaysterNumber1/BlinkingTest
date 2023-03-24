using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildBox : MonoBehaviour
{
    public GameObject box;
    public GameObject createdShape;
    public float width;
    private void OnCollisionEnter(Collision collision)
    {
        buildBox(collision.gameObject.GetComponent<DataForShelf>().height, collision.gameObject.GetComponent<DataForShelf>().depth,collision.gameObject);
    }
    public void buildBox(float height, float depth, GameObject parent) 
    {
       createdShape = Instantiate(box, this.transform.position, parent.transform.rotation, parent.transform);
       createdShape.transform.localScale = new Vector3(depth, height, width);
       createdShape.transform.localPosition = new Vector3(-depth/4, createdShape.transform.localPosition.y + height / 2, createdShape.transform.localPosition.z);
        createdShape.GetComponent<Item>().name= "Itemplaceholder";
       Destroy(this.gameObject);
    } 
}
