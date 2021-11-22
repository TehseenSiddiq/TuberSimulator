using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class VideoBtn : MonoBehaviour
{
    public static VideoBtn intance;

    //UI
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] Image topic1Image, topic2Image;

  
    public string videoName;
    public string[] names;
    public float time;

    VideoManager videoManager;
    public Topics topic1;
    public Topics topic2;

    private void Awake()
    {
        intance = this;
    }
    private void OnEnable()
    {
        videoManager = FindObjectOfType<VideoManager>();
        videoName = names[Random.Range(0, names.Length)];
        time = Random.Range(60, 360);
        topic1 = videoManager.topic[Random.Range(0, videoManager.topic.Length)];
        topic2 = videoManager.topic[Random.Range(0, videoManager.topic.Length)];
        nameText.text = videoName;
        float minutes = Mathf.FloorToInt(time / 60);
        float second = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{00:00}M:{01:00}S", minutes, second);
        topic1Image.sprite = topic1.image;
        topic2Image.sprite = topic2.image;
    }
}
