using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { Video,Cash,Fame}
[System.Serializable]
public class Quest 
{
    public string title;
    public int amount;
    public int amountMax;
    public int cash;
    public int fame;
    public Type type;

    public bool canCollect;
    public bool Collected;
}
