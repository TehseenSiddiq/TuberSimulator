using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject[] charactersMain;
    public GameObject[] hairs;
    public GameObject[] hairsMain;

    int characterIndex;
    int hairsIndex;
    public void Character(int index)
    {
        characterIndex += index;
        if(characterIndex > characters.Length || characterIndex < 0)
        {
            characterIndex = 0;
        }
        foreach(GameObject gameObject in characters)
        {
            gameObject.SetActive(false);
        }
        characters[characterIndex].SetActive(true);
    }
    public void Hairs(int index)
    {
        hairsIndex += index;
        if(hairsIndex > hairs.Length || hairsIndex < 0)
        {
            hairsIndex = 0;
        }
        
        foreach (GameObject gameObject in hairs)
        {
            gameObject.SetActive(false);
        }
        hairs[hairsIndex].SetActive(true);

    }
    public   void SetCharacter()
    {
        foreach (GameObject gameObject in charactersMain)
        {
            gameObject.SetActive(false);
        }
        charactersMain[characterIndex].SetActive(true);

        foreach (GameObject gameObject in hairsMain)
        {
            gameObject.SetActive(false);
        }
        hairsMain[hairsIndex].SetActive(true);

        FindObjectOfType<MenuUiManager>().CloseCharacterEditor();
    }
}
