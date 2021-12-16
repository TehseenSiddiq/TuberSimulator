using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    [SerializeField] GameObject prefab;
    public Button[] btns;
    [SerializeField] Transform content;
  //  [SerializeField] Image image;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for(int i = 0;i <= GameManager.intance.items.Count; i++)
        {
            GameObject a = Instantiate(prefab, content);
            btns[i] = a.GetComponent<Button>();
            btns[i].GetComponentInChildren<Image>().sprite = a.GetComponent<ObjectBehaviour>().objectImage;
        }
    }
}
