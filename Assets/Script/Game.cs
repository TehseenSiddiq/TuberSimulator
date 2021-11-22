using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game intance;

    //Base Values for game.............
    public static int fame;
    public static int cash;

    //Points......
    public static int gaming;
    public static int polictics;
    public static int pets;
    public static int home;
    public static int magic;
    public static int funny;
    public static int education;
    public static int makeup;

    private void Start()
    {
        LoadData();
    }
    public static void LoadData()
    {
        if (PlayerPrefs.HasKey("Fame"))
        {
            fame = PlayerPrefs.GetInt("Fame");
        }
        else
        {
            fame = 1;
             PlayerPrefs.SetInt("Fame",1);
        }
        if (PlayerPrefs.HasKey("Cash"))
        {
            cash = PlayerPrefs.GetInt("Cash");
        }
        else
        {
            PlayerPrefs.SetInt("Cash", 5000);
            cash = PlayerPrefs.GetInt("Cash");
            
        }
        if (PlayerPrefs.HasKey("gaming"))
        {
            gaming = PlayerPrefs.GetInt("gaming");
        }
        else
        {
            PlayerPrefs.SetInt("gaming", 1);
            gaming = PlayerPrefs.GetInt("gaming");
        }
        if (PlayerPrefs.HasKey("polictics"))
        {
            polictics = PlayerPrefs.GetInt("polictics");
        }
        else
        {
            polictics = 1;
            PlayerPrefs.SetInt("polictics", 1);
        }
        if (PlayerPrefs.HasKey("pets"))
        {
            pets = PlayerPrefs.GetInt("pets");
        }
        else
        {
            pets = 1;
            PlayerPrefs.SetInt("pets", 1);
        }
        if (PlayerPrefs.HasKey("home"))
        {
            home = PlayerPrefs.GetInt("home");
        }
        else
        {
            home = 1;
            PlayerPrefs.SetInt("Home", 1);
        }
        if (PlayerPrefs.HasKey("magic"))
        {
            magic = PlayerPrefs.GetInt("magic");
        }
        else
        {
            magic = 1;
            PlayerPrefs.SetInt("magic", 1);
        }
        if (PlayerPrefs.HasKey("funny"))
        {
            funny = PlayerPrefs.GetInt("funny");
        }
        else
        {
            funny = 1;
            PlayerPrefs.SetInt("funny", 1);
        }
        if (PlayerPrefs.HasKey("education"))
        {
            education = PlayerPrefs.GetInt("education");
        }
        else
        {
            PlayerPrefs.SetInt("education", 1);
            education = 1;
        }
        if (PlayerPrefs.HasKey("makeup"))
        {
            makeup = PlayerPrefs.GetInt("makeup");
        }
        else
        {
            PlayerPrefs.SetInt("makeup", 1);
            makeup = 1;
        }
    }
    public static void SaveData()
    {
        PlayerPrefs.SetInt("Fame", fame);
        PlayerPrefs.SetInt("Cash", cash);
        PlayerPrefs.SetInt("gaming",gaming);
        PlayerPrefs.SetInt("polictics", polictics);
        PlayerPrefs.SetInt("pets", pets);
        PlayerPrefs.SetInt("home", home);
        PlayerPrefs.SetInt("magic", magic);
        PlayerPrefs.SetInt("funny", funny);
        PlayerPrefs.SetInt("education", education);
        PlayerPrefs.SetInt("makeup", makeup);
    }
}