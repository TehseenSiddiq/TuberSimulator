using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EditorManager : MonoBehaviour
{

    public int phase = 1;
    public string[] options;
    public string select;
    public Image[] haiderBtn;
    public TextMeshProUGUI[] haiderText;
    public Button[] topicBtn;
    public TextMeshProUGUI[] text;
    public Color interactableColor;

    private void OnEnable()
    {
        phase = 1;
  

        Setting();
 
    }

    private void LateUpdate()
    {
       
        
    }

    public void OptionOne(int index)
    {
        if(select == options[index])
        {
            VideoManager.intance.reach += 4;
        }
        phase ++;
        if(phase > 3)
        {
            VideoManager.intance.EditeComplete();
        }
        Setting();
       
    }
    
    public void Setting()
    {
        Debug.Log("S");
        for (int i = 0; i < haiderBtn.Length; i++)
        {
            haiderBtn[i].color = interactableColor;
            haiderText[i].color = interactableColor;
        }

        haiderBtn[phase - 1].color = Color.white;
        haiderText[phase - 1].color = Color.white;

        for (int i = 0; i < options.Length; i++)
        {
            options[i] = Game.intance.topics[Random.Range(0, Game.intance.topics.Length)].name;
            text[i].text = options[i];
        }
        select = options[Random.Range(0, options.Length)];
    }
}
