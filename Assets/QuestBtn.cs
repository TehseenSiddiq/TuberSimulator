using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestBtn : MonoBehaviour
{
    public Slider slider;
    public TMP_Text titleText, rangeText;
    public TMP_Text cashText, fameText;
    public Image image;
    public int index;

    public void btn()
    {
        if (QuestManager.instance.quests[index].canCollect)
        {
            // Debug.Log("Index" + index );
            QuestManager.instance.quests[index].Collected = true;
            Game.cash += QuestManager.instance.quests[index].cash;
            Game.fame += QuestManager.instance.quests[index].fame;
            Game.totalQuest++;
            Destroy(QuestManager.instance.btns[index].gameObject);
            Game.intance.SaveData();
            ES3.Save("Quests", QuestManager.instance.quests);
           
        }  
    }
}
