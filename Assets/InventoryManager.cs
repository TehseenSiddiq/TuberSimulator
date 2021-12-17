using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    [SerializeField] GameObject prefab;
    public List<Button> btns;
    [SerializeField] Transform content;
  //  [SerializeField] Image image;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        this.Wait(1, () =>
        {

            for (int i = 0; i < GameManager.intance.items.Count; i++)
            {
                GameObject a = Instantiate(prefab, content);
                btns.Add(a.GetComponent<Button>());

                //   Debug.Log(GameManager.intance.items[i].name);
                
                SetInventory(i);
                btns[i].onClick.AddListener(()=>InventoryOut(i-1));
                Debug.Log(i);
            }
        });
    }

    public void SetInventory(int index)
    {
        btns[index].transform.GetChild(0).GetComponent<Image>().sprite = GameManager.intance.items[index].GetComponent<ObjectBehaviour>().objectImage;
        if (!GameManager.intance.items[index].GetComponent<ObjectBehaviour>().isInInventory)
        {
            btns[index].interactable = false;
            btns[index].transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            btns[index].interactable = true;
            btns[index].transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    void InventoryOut(int index)
    {
        Debug.Log("Index"+index);
        GameManager.intance.items[index].GetComponent<ObjectBehaviour>().isInInventory = false;
        GameManager.intance.items[index].GetComponent<ObjectBehaviour>().SaveInventoryState();
        GameManager.intance.items[index].SetActive(true);
        MenuUiManager.instance.BringInventory(3500);
        SetInventory(index);
    }
}
