using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    [SerializeField] GameObject simpleButton;
    [SerializeField] GameObject sellableButton;
    public List<Button> simpleBtns;
    [SerializeField] List<Button> sellableBtns;
    [SerializeField] Transform inventoryContent,sellContent,boostedContent;
    [SerializeField] GameObject sellConfirmPanel;
    [SerializeField] Button comfirmBtn, denieBtn;
  //  [SerializeField] Image image;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        this.Wait(1, () =>
        {
            CreateInventory(simpleButton, simpleBtns,inventoryContent);
            CreateInventory(sellableButton, sellableBtns,sellContent);
            for (int i = 0; i < GameManager.intance.items.Count; i++)
            {
                SetInventory(i);
                btnSetup(i);
            }
            
        });
    }

    public void CreateInventory(GameObject prefab,List<Button> btns,Transform content)
    {
       // Debug.Log(GameManager.intance.items.Count);
        for (int i = 0; i < GameManager.intance.items.Count; i++)
        {            
            //Debug.Log(GameManager.intance.items[i].name);
            GameObject a = Instantiate(prefab, content);
            btns.Add(a.GetComponent<Button>());  
        }
        
    }

    void btnSetup(int i)
    {

        simpleBtns[i].onClick.AddListener(() => InventoryOut(i));
        sellableBtns[i].onClick.AddListener(() => SellItem(i));
    }
    public void SetInventory(int index)
    {
        Setup(index, simpleBtns);
        Setup(index, sellableBtns);
    }
    void Setup(int index, List<Button> btns)
    {
        btns[index].transform.GetChild(0).GetComponent<Image>().sprite = GameManager.intance.items[index].GetComponent<ObjectBehaviour>().objectImage;
        Debug.Log("Index: "+ index);
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
          GameManager.intance.items[index].GetComponent<ObjectBehaviour>().isInInventory = false;
          GameManager.intance.items[index].GetComponent<ObjectBehaviour>().SaveInventoryState();
          GameManager.intance.items[index].SetActive(true);
          MenuUiManager.instance.BringInventory(3500);
          SetInventory(index);
      //  Debug.Log("Index " + index);
    }
    void SellItem(int index)
    {
        if(!sellableBtns[index].GetComponent<SellInfo>().isSelected)
        {
            sellableBtns[index].GetComponent<SellInfo>().isSelected = true;
            sellableBtns[index].transform.GetChild(2).gameObject.SetActive(true);
            sellableBtns[index].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "$" + Mathf.RoundToInt(GameManager.intance.items[index].GetComponent<ObjectBehaviour>().price *0.6f);
            sellableBtns[index].transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            sellableBtns[index].GetComponent<SellInfo>().isSelected = false;
            sellConfirmPanel.SetActive(true);
            comfirmBtn.onClick.AddListener(()=>SellConfim(index));
            denieBtn.onClick.AddListener(()=>SellDenie(index));
        }
    }
    void SellConfim(int index)
    {
        GameManager.intance.items.Remove(GameManager.intance.items[index]);
        Game.cash += Mathf.RoundToInt(GameManager.intance.items[index].GetComponent<ObjectBehaviour>().price / 1.5f);
        CreateInventory(simpleButton, simpleBtns, inventoryContent);
        CreateInventory(sellableButton, sellableBtns, sellContent);
        GameManager.intance.SaveItemList();
        MenuUiManager.instance.BringInventory(3500);
    }
    void SellDenie(int index)
    {
        sellableBtns[index].GetComponent<SellInfo>().isSelected = false;
        sellableBtns[index].transform.GetChild(2).gameObject.SetActive(false);
        sellableBtns[index].transform.GetChild(1).gameObject.SetActive(false);
        sellConfirmPanel.SetActive(false);
     //   MenuUiManager.instance.BringInventory(3500);
    }
}
