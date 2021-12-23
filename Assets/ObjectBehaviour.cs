using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    public static ObjectBehaviour instance;
    [SerializeField] string KeyCode;
    bool justSpawned = false;
    [SerializeField] Topics topic;
    [SerializeField] category category;
    public float min = 1.2f, max = 0.9f;
    public bool isInInventory = false;
    public Sprite objectImage;
    int index;
    public int price;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (justSpawned)
        {
            ObjectHandler.instance.Spawn(this.gameObject);
        }
        Load();
        for(int i = 0;i < GameManager.intance.items.Count; i++)
        {
            if(GameManager.intance.items[i].transform == this.transform)
            {
                index = i;
            }
        }
        isInInventory = ES3.Load("Inventory" + KeyCode, isInInventory);
        if (isInInventory)
        {
            gameObject.SetActive(false);
        }
        price = FindObjectOfType<BtnManager>().itemPropertie[index].price;
    }
    private void OnEnable()
    {
      
    }
    private void Load()
    {
        transform.position = ES3.Load(KeyCode, transform.position);
        transform.eulerAngles = ES3.Load("Angles" + KeyCode, transform.eulerAngles);
    }
    public void ObjectPoint()
    {
        foreach (Topics topic2 in Game.intance.topics)
        {
            switch (category)
            {
                case category.nature:
                    Game.intance.topics[0].value++;
                    break;
                case category.gaming:
                    Game.intance.topics[1].value++;
                    break;
                case category.funny:
                    Game.intance.topics[2].value++;
                    break;
                case category.pets:
                    Game.intance.topics[3].value++;
                    break;
                case category.polictics:
                    Game.intance.topics[4].value++;
                    break;
                case category.home:
                    Game.intance.topics[5].value++;
                    break;
                case category.magic:
                    Game.intance.topics[6].value++;
                    break;
                case category.makeup:
                    Game.intance.topics[7].value++;
                    break;
                case category.education:
                    Game.intance.topics[8].value++;
                    break;
                case category.science:
                    Game.intance.topics[9].value++;
                    break;

            }
        }
    }
    private void OnDisable()
    {
        SavePos();
    }
    private void OnApplicationQuit()
    {
        //SavePos();
    }
    public void SavePos()
    {
        ES3.Save(KeyCode, transform.position);
        ES3.Save("Angles" + KeyCode, transform.eulerAngles);
    }
    public void Inventory()
    {
        
        isInInventory = true;
        InventoryManager.instance.SetInventory(index);
        SaveInventoryState();
        gameObject.SetActive(false);
    }
    public void SaveInventoryState()
    {
        ES3.Save("Inventory" + KeyCode, isInInventory);
    }
}
