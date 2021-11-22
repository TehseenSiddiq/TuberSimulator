using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class VideoManager : MonoBehaviour
{
    public static VideoManager intance;

    public Topics[] topic;
    public Topics[] trendingTopics;
    public GameObject[] menus;
    public int reach;
    int cashMul, subMul;
    public TextMeshProUGUI rewardText;

    private void Awake()
    {
        intance = this;
    }

    void TopicValue()
    {
        topic[0].value = PlayerPrefs.GetInt("gaming");
        topic[1].value = PlayerPrefs.GetInt("polictics");
        topic[2].value = PlayerPrefs.GetInt("pets");
        topic[3].value = PlayerPrefs.GetInt("home");
        topic[4].value = PlayerPrefs.GetInt("magic");
        topic[5].value = PlayerPrefs.GetInt("funny"); 
        topic[6].value = PlayerPrefs.GetInt("education");
        topic[7].value = PlayerPrefs.GetInt("makeup");
    }
    private void Start()
    {
        TopicValue();
        trendingTopics[0] = topic[Random.Range(0, topic.Length)];
        trendingTopics[1] = topic[Random.Range(0, topic.Length)];
    }

    public void OnClick_SelectTopic()
    {
        reach += EventSystem.current.currentSelectedGameObject.GetComponent<VideoBtn>().topic1.value + EventSystem.current.currentSelectedGameObject.GetComponent<VideoBtn>().topic2.value;
        Debug.Log(reach);
        menus[0].SetActive(false);
        menus[1].SetActive(true);
    }

    public void OnClick_EventSelect()
    {
        if(EventSystem.current.currentSelectedGameObject.name == "Promotion")
        {
            subMul = 2;
            cashMul = 3;
            menus[1].SetActive(false);
            menus[2].SetActive(true);
        }
        else if(EventSystem.current.currentSelectedGameObject.name == "Sponsored")
        {
            subMul = 3;
            cashMul = 2;
            menus[1].SetActive(false);
            menus[2].SetActive(true);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Commersial")
        {
            subMul = 1;
            cashMul = 4;
            menus[1].SetActive(false);
            menus[2].SetActive(true);
        }
    }
    public void EditeComplete()
    {
        RenderManager.intance.isRendering = true;
        menus[2].SetActive(false);
        menus[3].SetActive(true);
    }
    public void Submit()
    {
        reach = reach * Random.Range(100, 150);
       // cashMul = reach / cashMul;
       // subMul = reach / subMul;
        menus[3].SetActive(false);
        menus[4].SetActive(true);
        rewardText.text = "You Earnend \n" + reach;
    }
}
