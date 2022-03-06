using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audioSource,musicSource;

    [SerializeField] List<Button> btns;
    [SerializeField] Slider sound,music;


    public void Start()
    {
        musicSource.Play();
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(Play);
        }
    }
    private void Play()
    {
      
        audioSource.Play();
        
    }
    private void LateUpdate()
    {
        audioSource.volume = sound.value;
        musicSource.volume = music.value;

    }

}
