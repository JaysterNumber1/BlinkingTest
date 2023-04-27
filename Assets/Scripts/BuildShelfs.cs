using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BuildShelfs : MonoBehaviour
{
    public GameObject shelfParent; //an empty game object used to create everything under one object that can be saved to a prefab
    public GameObject basicShelf;
    public GameObject shelf;
    public ContentSizeFitter content;
    public List<GameObject> shelfList;
    public float depth = 25; // the depth of the shelf
    public float width = 50; // the width of the shelf
    public float defHeight = 50;
    public List<GameObject> HeightFieldList;
    public List<float> heights;
    public float shelfThickness = 2;
    public bool uniformShelfHeightBool = true;
    public int shelfNumber = 4;
    public string shelfName;
    public TMP_InputField shelfNameInput;
    public TMP_InputField widthInput;
    public TMP_InputField depthInput;
    public GameObject HeightField;
    public TMP_InputField heightInput;
    public TMP_InputField shelfNumberInput;
    public UnityEngine.UI.Toggle uniformShelfHeightToggle;
    // public bool doubleSideded = false; // not used yet

    private void Start() //sets defualt values
    {
        widthInput.text = width.ToString();
        depthInput.text = depth.ToString();
        shelfNumberInput.text = shelfNumber.ToString();
        uniformShelfHeightBool = false;
        shelfNumberInput.gameObject.SetActive(true);
        BuildShelf();

    }
    public void BuildShelf()
    {
        GameObject lastShelf;
        
        DestroyShelf();
        for (int i = 0; i < shelfNumber; i++)
        {
            if (i >= 1)
            {
                lastShelf = shelf;
            }
            else
            {
                lastShelf = null;
            }
            shelf = Instantiate(basicShelf, this.transform.position, shelfParent.transform.rotation, shelfParent.transform); 
            shelf.transform.localScale = new Vector3(depth/100, shelfThickness/100, width / 100);
            if (shelfNumber > 1 && uniformShelfHeightBool)
            {
                shelf.transform.localPosition = new Vector3(0, shelf.transform.localPosition.y + ((defHeight / (shelfNumber - 1)) * i) / 100, shelf.transform.localPosition.z);
            } else if (shelfNumber < 1)
            {
                Debug.Log("Yo no work");
            }
            else if (shelfNumber > 1 && lastShelf != null)
            {
                shelf.transform.localPosition = new Vector3(0, lastShelf.transform.localPosition.y + heights[i + 1], 0);
            }
            else
            {
                shelf.transform.localPosition = new Vector3(0, 0, shelf.transform.localPosition.z);
            }


            shelf.name = "shelf" + i;

            shelfList.Add(shelf);
        }
    }
    public void DestroyShelf()
    {
        
            for (int i = shelfList.Count-1; i >= 0; i--)
            {
            Destroy(shelfList[i]);
            //shelfList.RemoveAt(i);
           
            }
        
    }

    //edit stuff from input fields

    
    public void EditShelfWidth()
    {
        width = float.Parse(widthInput.text);
    }
    public void EditShelfDepth()
    {
        depth = float.Parse(depthInput.text);
    }
    public void EditShelfNumber()
    {
        shelfNumber = int.Parse(shelfNumberInput.text);
        if (!uniformShelfHeightBool)
        {
            UpdateHeights();
        }
    }
    public void EditShelfName()
    {
        shelfName = shelfNameInput.text;
    }
    
    public void UniformShelfToggle()
    {
        //shelfNumberInput.transform.parent.gameObject.SetActive(!uniformShelfHeightToggle);
        if (uniformShelfHeightBool)
        {
            uniformShelfHeightBool = false;
        } else if (!uniformShelfHeightBool)
        {
            uniformShelfHeightBool= true;
        }
        UpdateHeights();
        
    }

    public void UpdateHeights()
    {
        for (int i = HeightFieldList.Count - 1; i >= 0; i--)
        {
            Destroy(HeightFieldList[i]);
        }
        HeightFieldList.Clear();

        if(uniformShelfHeightBool==false) 
        {

            for(int i = 1; i < shelfNumber; i++)
            {
                GameObject newHeightField = Instantiate(HeightField, content.transform);
                
                HeightFieldList.Add(newHeightField);
            }
        }
    }
}
