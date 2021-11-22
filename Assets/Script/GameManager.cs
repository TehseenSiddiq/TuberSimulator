using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;

    public Transform spawnPos;

    private void Awake()
    {
        intance = this;
    }
}
