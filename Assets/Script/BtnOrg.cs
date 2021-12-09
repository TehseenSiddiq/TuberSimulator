using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnOrg : MonoBehaviour
{
    public Image image;
    public TMP_Text priceText, timeText, levelText;
    public Image type,typeBg;
    public int price;
    public float time;
    public GameObject prefab;

    private void Start()
    {
       
    }
    public void SetPrice(float price)
    {
        priceText.text = string.Format("{0:0,0}", price);
    }
    public void SetTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void SetLevel(int level)
    {
        levelText.text = "Lvl. " + level; 
    }
    public void SetSprite(Sprite sp)
    {
        image.sprite = sp;
    }
    public void SetCat(category a,Sprite[] sp)
    {
        switch (a)
        {
            case category.nature:
                type.sprite = sp[0];
                break;
            case category.gaming:
                type.sprite = sp[1];
                break;
            case category.funny:
                type.sprite = sp[2];
                break;
            case category.pets:
                type.sprite = sp[3];
                break;
            case category.polictics:
                type.sprite = sp[4];
                break;
            case category.home:
                type.sprite = sp[5];
                break;
            case category.magic:
                type.sprite = sp[6];
                break;
            case category.makeup:
                type.sprite = sp[7];
                break;
            case category.education:
                type.sprite = sp[8];
                break;
            case category.science:
                type.sprite = sp[9];
                break;

        }
    }
    public void BuyPrefab()
    {
        if(Game.cash > price)
        {
            GameObject a = Instantiate(prefab, GameManager.intance.spawnPos.position, prefab.transform.rotation);
            GameManager.intance.AddItem(a);

            //a.GetComponent<ObjectBehivour>().justSpawned = true;
            //   a.GetComponent<ObjectBehivour>().spawnTime = time;
            ObjectHandler.instance.spawnTime = time;
            ObjectHandler.instance.totalTime = time;

            a.GetComponent<ObjectBehaviour>().ObjectPoint();
            MenuUiManager.instance.ShopMenu(3500);
            Game.cash -= price;
            Game.totalItems++;
            Game.intance.SaveData();
        }
      
    }
    
}
