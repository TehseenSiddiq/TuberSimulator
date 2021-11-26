using DG.Tweening;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
    public static GuiManager intance;

    public Sprite[] btnBackground;
    public Sprite[] icons;

    private void Awake()
    {
        intance = this;
    }

    public void OpenRotate(GameObject a,Vector3 toPos,float duration)
    {
        a.transform.DORotate(toPos, duration);
    }
    public static void OpenDrag(RectTransform a,Vector3 toPos,float duration)
    {
        a.DOAnchorPos(toPos, duration,false);
    }
    
}
