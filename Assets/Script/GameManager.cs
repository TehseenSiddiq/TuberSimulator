using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;

    public Transform spawnPos;
    public List<GameObject> items;
  //  public List<Transform> itemsTransform;

    private void Awake()
    {
        //  ES3.DeleteKey("Items");
     //   ES3.DeleteFile("Items");
        intance = this;
        items = ES3.Load("Items", items);
      //  itemsTransform = ES3.Load("ItemTransform", itemsTransform);
    }
    private void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Instantiate(items[i]);
        }
    }
    public void SaveItemList()
    {
        ES3.Save("Items", items);
       // ES3.Save("ItemTransform", itemsTransform);
    }
    public void AddItem(GameObject prefab)
    {  
        //GameObject a = Instantiate(prefab, trans.position, Quaternion.identity);
        
        items.Add(prefab);
       // itemsTransform.Add(a.transform);
        ES3.Save("Items", items);
      //  ES3.Save("ItemTransform", itemsTransform);
    }
}
