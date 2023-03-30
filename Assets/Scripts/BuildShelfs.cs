using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BuildShelfs : MonoBehaviour
{
    public GameObject shelfParent;
    public GameObject basicShelf;
    public List<GameObject> shelfList;
    public float depth = 25;
    public float width = 50;
    public float defHeight = 50;
    public float shelfThickness = 2;
    public int shelfNumber = 4;
    public string shelfName;
    public TMP_InputField shelfNameInput;
    public TMP_InputField widthInput;
    public TMP_InputField depthInput;
    public TMP_InputField shelfNumberInput;
    // public bool doubleSidded = false; // not used yet

    private void Start()
    {
        widthInput.text = width.ToString();
        depthInput.text = depth.ToString();
        shelfNumberInput.text = shelfNumber.ToString();
        BuildShelf();

    }
    public void BuildShelf()
    {
        DestroyShelf();
        for (int i = 0; i < shelfNumber; i++)
        {

            GameObject shelf = Instantiate(basicShelf, this.transform.position, shelfParent.transform.rotation, shelfParent.transform);
            shelf.transform.localScale = new Vector3(depth/100, shelfThickness/100, width / 100);
            if (shelfNumber > 1)
            {
                shelf.transform.localPosition = new Vector3(0, shelf.transform.localPosition.y + ((defHeight / (shelfNumber - 1)) * i) / 100, shelf.transform.localPosition.z);
            }else if (shelfNumber < 1)
            {
                Debug.Log("Yo no work");
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
    }
    public void EditShelfName()
    {
        shelfName = shelfNameInput.text;
    }
}
