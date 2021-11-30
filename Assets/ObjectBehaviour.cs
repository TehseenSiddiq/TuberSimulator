using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    public static ObjectBehaviour instance;
    [SerializeField] string KeyCode;

    public float min = 1.2f, max = 0.9f;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        transform.position = ES3.Load(KeyCode, transform.position);
        transform.eulerAngles = ES3.Load("Angles"+KeyCode, transform.eulerAngles);
    }
    private void OnDisable()
    {
        SavePos();
    }
    private void OnApplicationQuit()
    {
        SavePos();
    }
    public void SavePos()
    {
        ES3.Save(KeyCode, transform.position);
        ES3.Save("Angles" + KeyCode, transform.eulerAngles);
    }
}
