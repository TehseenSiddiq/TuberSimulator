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

    public TMP_Text cashText, fameText;

    [Header("Panels")]
    [SerializeField] RectTransform LeaderBoard;
    [SerializeField] RectTransform Setting;
    [SerializeField] RectTransform Inventory;
    [SerializeField] RectTransform characterCustimization;
    [SerializeField] Transform characterDummy;
    [SerializeField] RectTransform characterPanel;
    [SerializeField] RectTransform shopMenu;

    private void Awake()
    {
        instance = this;
    }
    private void LateUpdate()
    {
        cashText.text = string.Format("{0:0,0}", Game.cash);
        fameText.text = string.Format("{0,0}",Game.fame);
    }
    public void BringLeaderboard(float a)
    {
        GuiManager.intance.OpenDrag(LeaderBoard, new Vector3(a, 0, 0), dargSpeed);

    }
    public void BringSetting(float a)
    {
        GuiManager.intance.OpenDrag(Setting, new Vector3(a, 0, 0), dargSpeed);

    }
    public void BringInventory(float a)
    {
        GuiManager.intance.OpenDrag(Inventory, new Vector3(a, 0, 0), dargSpeed);

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
            GuiManager.intance.OpenDrag(UpperMenu,new Vector3(25,-180,0), dargSpeed);
        else
        {
            GuiManager.intance.OpenDrag(UpperMenu, new Vector3(25, 2000, 0), dargSpeed);
        }
    }
    public void Darg(float index)
    {
        GuiManager.intance.OpenDrag(UpperMenu, new Vector3(25, index, 0), dargSpeed);
    }
    public void OpenCharacterEditor()
    {
        GuiManager.intance.OpenDrag(characterCustimization, new Vector3(0, 0, 0), dargSpeed);
        characterDummy.DOMove(new Vector3(-14, 5, 13), dargSpeed);
    }
    public void CloseCharacterEditor()
    {
        GuiManager.intance.OpenDrag(characterCustimization, new Vector3(-800, 0, 0), dargSpeed);
        characterDummy.DOMove(new Vector3(50, 0, 13), dargSpeed);
    }
    public void ShopMenu(int a)
    {
        GuiManager.intance.OpenDrag(shopMenu, new Vector3(a, 0, 0), dargSpeed);
      //  characterDummy.DOMove(new Vector3(50, 0, 13), dargSpeed);
    }
}