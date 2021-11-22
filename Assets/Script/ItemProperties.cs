using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemProperties 
{
    public int level;
    public int price;
    public category category;
    public float timeToSpawn;
    public Sprite image;
}
public enum category { nature,gaming,funny,pets,polictics,home,magic,makeup,education,science}
