using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;

    public Transform spawnPos;
   // public GameObject[] items;
    public List<GameObject> items;
  //  public List<Transform> itemsTransform;
 //   public List<Vector3> rotations;

    private void Awake()
    {
        //  ES3.DeleteKey("Items2");
     //   ES3.DeleteFile("Items");
        intance = this;
        
        
      //  itemsTransform = ES3.Load("ItemTransform", itemsTransform);
    }
    private void Start()
    {
        //  ES3.DeleteKey("Items2");

        LoadItemList();
       // itemsList = items.ToList();
        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log("Instantiating: " + items[i].name);
         //  itemsTransform[i] = items[i].transform;
         //   Instantiate(items[i]);
        }
        Debug.Log("Size " + items.Count);
    }
    public void LoadItemList()
    {
        items = ES3.Load("Items2", items);
    }
    public void SaveItemList()
    {
       // items = itemsList.ToArray();
        ES3.Save("Items2", items);
       // ES3.Save("ItemTransform", itemsTransform);
    }
    public void AddItem(GameObject prefab)
    {  
        //GameObject a = Instantiate(prefab, trans.position, Quaternion.identity);
        
        items.Add(prefab);
        // itemsTransform.Add(a.transform);
        SaveItemList();
      //  ES3.Save("ItemTransform", itemsTransform);
    }
    
}
