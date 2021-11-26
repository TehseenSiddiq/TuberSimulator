using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class VideoBtn : MonoBehaviour
{
    public static VideoBtn intance;

    //UI
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] Image topic1Image, topic2Image,topic1BG,topic2BG;

  
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
        //Debug.Log(Game.intance.topics.Length);
        topic1 = Game.intance.topics[Random.Range(0, Game.intance.topics.Length)];
        topic2 = Game.intance.topics[Random.Range(0, Game.intance.topics.Length)];
        nameText.text = videoName;
        float minutes = Mathf.FloorToInt(time / 60);
        float second = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{00:00}M:{01:00}S", minutes, second);
         topic1Image.sprite = topic1.itemImage;
        topic2Image.sprite = topic2.itemImage;
    }
}
