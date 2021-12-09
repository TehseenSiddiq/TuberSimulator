using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class RenderManager : MonoBehaviour
{
    public static RenderManager intance;

    public bool isRendering = false;
    public Slider slider;
    public int percentage = 100;
    public TextMeshProUGUI timerText;
    public float timer;
    public TextMeshProUGUI percentageText;
    public Button submitBtn;
    bool isTimeSet = false;

    private void Start()
    {
        intance = this;
       
        
        
    }
    public void Update()
    {
        
        if(percentage < 100 && isRendering)
        {
            if (!isTimeSet)
            {
                timer = VideoBtn.intance.time;
                isTimeSet = true;
            }
            timer -= 2*Time.deltaTime;
            percentage = 100 - Mathf.RoundToInt((timer / VideoBtn.intance.time) * 100);
           
            float minutes = Mathf.FloorToInt(timer / 60);
            float second = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{00:00}M:{01:00}S", minutes, second);
            slider.value = percentage;
            percentageText.text = percentage+"%";
            submitBtn.interactable = false;
        }
        
        
        if(percentage == 100)
        {
            submitBtn.interactable = true;
            timerText.text = "Done!";
        }
    }
    public void Reset()
    {
        percentage = 0;
        isRendering = false;
        timer = 0;
        isTimeSet = false;
        submitBtn.interactable = false;

    }
    public void Submit()
    {
        VideoManager.intance.Submit();
        isTimeSet = false;
    }
}
