using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;

    public Transform spawnPos;
    public GameObject[] items;
    public List<GameObject> itemsLists;
  //  public List<Transform> itemsTransform;

    private void Awake()
    {
        //  ES3.DeleteKey("Items");
     //   ES3.DeleteFile("Items");
        intance = this;
        
        
      //  itemsTransform = ES3.Load("ItemTransform", itemsTransform);
    }
    private void Start()
    {
      //  ES3.DeleteKey("Items");
        
        items = ES3.Load("Items", items);
        itemsLists = items.ToList();
        for (int i = 0; i < itemsLists.Count; i++)
        {
            Instantiate(itemsLists[i]);
        }
    }
    public void SaveItemList()
    {
        items = itemsLists.ToArray();
        ES3.Save("Items", items);
       // ES3.Save("ItemTransform", itemsTransform);
    }
    public void AddItem(GameObject prefab)
    {  
        //GameObject a = Instantiate(prefab, trans.position, Quaternion.identity);
        
        itemsLists.Add(prefab);
        // itemsTransform.Add(a.transform);
        SaveItemList();
      //  ES3.Save("ItemTransform", itemsTransform);
    }
    
}
