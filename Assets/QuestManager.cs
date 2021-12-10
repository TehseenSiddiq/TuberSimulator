using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public List<Quest> quests;
    public GameObject prefab;
    public Transform content;
    public List<GameObject> btns;
    public Sprite sp;

    public List<GameObject> objects;

    private void Awake()
    {
        instance = this;

        quests = ES3.Load("Quests", quests);
        for (int i = 0; i < quests.Count; i++)
        {
            if (!quests[i].Collected)
            {
                GameObject a = Instantiate(prefab, content);

                btns.Add(a);
                a.GetComponent<QuestBtn>().titleText.text = quests[i].title;
                a.GetComponent<QuestBtn>().index = i;
                a.GetComponent<QuestBtn>().slider.maxValue = quests[i].amountMax;
                a.GetComponent<QuestBtn>().slider.value = quests[i].amount;
                a.GetComponent<QuestBtn>().cashText.text = quests[i].cash.ToString();
                a.GetComponent<QuestBtn>().fameText.text = quests[i].fame.ToString();
                a.GetComponent<QuestBtn>().rangeText.text = quests[i].amount + "/" + quests[i].amountMax;
            }
         
        }
    }
    private void Start()
    {
        objects = ES3.Load("Objects",objects);
    }
    private void LateUpdate()
    {
       // Debug.Log("Video " + Game.totalVideos);
        for (int i = 0; i < quests.Count; i++)
        {
            if (!quests[i].Collected)
            {
                switch (quests[i].type)
                {
                    case Type.Video:
                        quests[i].amount = Game.totalVideos;
                        break;
                    case Type.Cash:
                        quests[i].amount = Game.cash;
                        break;
                    case Type.Fame:
                        quests[i].amount = Game.fame;
                        break;
                }

                btns[i].GetComponent<QuestBtn>().slider.maxValue = quests[i].amountMax;
                btns[i].GetComponent<QuestBtn>().slider.value = quests[i].amount;
                btns[i].GetComponent<QuestBtn>().rangeText.text = quests[i].amount + "/" + quests[i].amountMax;
                if (quests[i].amount >= quests[i].amountMax)
                {
                    btns[i].GetComponent<QuestBtn>().image.sprite = sp;
                    quests[i].canCollect = true;
                }
            }

        }
    }

 
}
