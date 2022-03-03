using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;

    public Transform spawnPos;
    public List<GameObject> items;


    private void Awake()
    {
        intance = this;
    }
    private void Start()
    {
        LoadItemList();
    }
    public void LoadItemList()
    {
        items = ES3.Load("Items2", items);
    }
    public void SaveItemList()
    {
       
        ES3.Save("Items2", items);
    }
    //This function is called when we buy new item so we add the item to list and then again save the list
    public void AddItem(GameObject prefab)
    {  
       
        items.Add(prefab);
        SaveItemList();
    }
    
}
