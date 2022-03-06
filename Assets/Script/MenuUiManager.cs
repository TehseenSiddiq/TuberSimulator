using DG.Tweening;
using TMPro;
using UnityEngine;

public class MenuUiManager : MonoBehaviour
{
    public static MenuUiManager instance;

    public GameObject[] elements;
    public float elementRotateSpeed= 1;
    [SerializeField] float delay = 1;

    [Header("MenuSetting")]
    [SerializeField] RectTransform UpperMenu;
    public float dargSpeed = 1f;

    [Header("Text")]
    public TMP_Text cashText, fameText;
    public TMP_Text statics;

    [Header("Panels")]
    [SerializeField] RectTransform LeaderBoard;
    [SerializeField] RectTransform Setting;
    [SerializeField] RectTransform Inventory;
    [SerializeField] RectTransform characterCustimization;
    [SerializeField] Transform characterDummy;
    [SerializeField] RectTransform characterPanel;
    [SerializeField] RectTransform shopMenu;
    [SerializeField] RectTransform communityPanel;
    [SerializeField] RectTransform questPanel;
    public GameObject[] panels;
    public RectTransform SplashScreen;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        this.Wait(5, () =>
        {
            SplashScreen.transform.DORotate(new Vector3(0, 0, 50), 1, RotateMode.Fast);
            SplashScreen.transform.DOScale(0, 2.5f);
            GuiManager.OpenDrag(SplashScreen, new Vector3(3500, 0, 0), 3);
        });
    }
    private void LateUpdate()
    {
        cashText.text = string.Format("{0:0,0}", Game.cash);
        fameText.text = string.Format("{0,0}",Game.fame);
        statics.text = "Start Date:" +
            "\nDaily Quest Completed:" + Game.totalQuest +
            "\nVideos Published:" + Game.totalVideos +
            "\nTotal Item Purchased:" + Game.totalItems;
    }
    public void BringLeaderboard(float a)
    {
        GuiManager.OpenDrag(LeaderBoard, new Vector3(a, 0, 0), dargSpeed);

    }
    public void BringSetting(float a)
    {
        GuiManager.OpenDrag(Setting, new Vector3(a, 0, 0), dargSpeed);

    }
    public void BringInventory(float a)
    {
        GuiManager.OpenDrag(Inventory, new Vector3(a, 0, 0), dargSpeed);

    }
    public void OpenRotate(int a)
    {
        foreach (GameObject Object in elements)
        {
            GuiManager.intance.OpenRotate(Object, new Vector3(0, 90, 0), elementRotateSpeed);
        }
        this.Wait(delay, () =>
        {
            GuiManager.intance.OpenRotate(elements[a], new Vector3(0, 0, 0), elementRotateSpeed);
        });
    }
    public void CloseRotate(int a)
    {
        GuiManager.intance.OpenRotate(elements[a], new Vector3(0, 90, 0), elementRotateSpeed);
    }
    public void UpperMenuDarg()
    {
        if(UpperMenu.anchoredPosition.y > 0)   
            GuiManager.OpenDrag(UpperMenu,new Vector3(25,-180,0), dargSpeed);
        else
        {
            GuiManager.OpenDrag(UpperMenu, new Vector3(25, 2000, 0), dargSpeed);
        }
    }
    public void UpperMenuDarg(int a)
    {
        GuiManager.OpenDrag(UpperMenu, new Vector3(25, a, 0), dargSpeed);

    }
    public void Darg(float index)
    {
        GuiManager.OpenDrag(UpperMenu, new Vector3(25, index, 0), dargSpeed);
    }
    public void OpenCharacterEditor()
    {
        GuiManager.OpenDrag(characterCustimization, new Vector3(0, 0, 0), dargSpeed);
      //  characterDummy.DOMove(new Vector3(-14, 5, 13), dargSpeed);
    }
    public void CloseCharacterEditor()
    {
        GuiManager.OpenDrag(characterCustimization, new Vector3(-3500, 0, 0), dargSpeed);
     //   characterDummy.DOMove(new Vector3(50, 0, 13), dargSpeed);
    }
    public void CloseCharacterPanel()
    {
        GuiManager.OpenDrag(characterPanel, new Vector3(-3500, 0, 0), dargSpeed);
    }
    public void OpenCharacterPanel()
    {
        GuiManager.OpenDrag(characterPanel, new Vector3(0, 0, 0), dargSpeed);
    }
    public void ShopMenu(int a)
    {
        GuiManager.OpenDrag(shopMenu, new Vector3(a, 0, 0), dargSpeed);
      //  characterDummy.DOMove(new Vector3(50, 0, 13), dargSpeed);
    }
    public void ToggleCommunityPanel(int a)
    {
        GuiManager.OpenDrag(communityPanel, new Vector3(a, 0, 0), dargSpeed);
    }
    public void ToggleQuestPanel(int a)
    {
        GuiManager.OpenDrag(questPanel, new Vector3(a, 0, 0), dargSpeed);
    }
    public void OffOnPanels(int a)
    {
        foreach(GameObject panel in panels)
        {
            panel.SetActive(false);
        }
        panels[a].SetActive(true);
    }
   public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
