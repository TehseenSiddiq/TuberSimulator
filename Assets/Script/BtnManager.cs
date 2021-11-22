using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public ItemProperties[] itemPropertie;
    public GameObject prefab;
    public GameObject[] modelPrefab;
    public Transform container;
    public Sprite[] catSp;

    private void Start()
    {
        for (int i = 0; i < itemPropertie.Length; i++)
        {
            GameObject a = Instantiate(prefab,container);
            //a.transform = container
            a.GetComponent<BtnOrg>().SetLevel(itemPropertie[i].level);
            a.GetComponent<BtnOrg>().SetPrice(itemPropertie[i].price);
            a.GetComponent<BtnOrg>().SetTime(itemPropertie[i].timeToSpawn);
            a.GetComponent<BtnOrg>().SetSprite(itemPropertie[i].image);
            a.GetComponent<BtnOrg>().price = itemPropertie[i].price;
            a.GetComponent<BtnOrg>().SetCat(itemPropertie[i].category, catSp);
            a.GetComponent<BtnOrg>().prefab = modelPrefab[i];
            a.GetComponent<BtnOrg>().time = itemPropertie[i].timeToSpawn;
        }
    }
}
