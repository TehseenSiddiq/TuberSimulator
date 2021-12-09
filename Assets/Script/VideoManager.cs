using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class VideoManager : MonoBehaviour
{
    public static VideoManager intance;

    Topics[] topics;
    public Topics[] trendingTopics;
    public RectTransform mainPage;
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
        topics = Game.intance.topics;
    }
    private void Start()
    {
        TopicValue();
        trendingTopics[0] = topics[Random.Range(0, topics.Length)];
        trendingTopics[1] = topics[Random.Range(0, topics.Length)];

    }

    public void OnClick_SelectTopic()
    {
        reach += EventSystem.current.currentSelectedGameObject.GetComponent<VideoBtn>().topic1.value + EventSystem.current.currentSelectedGameObject.GetComponent<VideoBtn>().topic2.value;
      //  Debug.Log(reach);
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
    public void Finish(int index)
    {
        if (index == 0)
            menus[0].SetActive(true);
        else
        {
            menus[4].SetActive(false);
            Game.cash += reach;
           
            Game.totalVideos++;
            Game.intance.SaveData();
            reach = 0;
            FindObjectOfType<EditorManager>().phase = 1;
            FindObjectOfType<EditorManager>().Setting();
            RenderManager.intance.Reset();
        }
        GuiManager.OpenDrag(mainPage, new Vector3(index, 0, 0), MenuUiManager.instance.dargSpeed);

    }
    public void CloseOpen(int index)
    {
        if (!menus[0].activeSelf && !menus[1].activeSelf && !menus[2].activeSelf && !menus[3].activeSelf)
            menus[0].SetActive(true);
        GuiManager.OpenDrag(mainPage, new Vector3(index, 0, 0), MenuUiManager.instance.dargSpeed);
    }
}
