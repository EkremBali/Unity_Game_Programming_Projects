using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;


public class level : MonoBehaviour
{
    public Slider slider;
    public Text levelint;
    string levelstr;
    public int levelDeger=300;
    public Text levelDegerint;
    string levelDegerStr;
    public Text genelPara;
    string genelParaStr;
    int genelParaInt;
    

    void Start()
    {
    }

    void Update()
    {
        genelParaStr = genelPara.text;
        genelParaInt=Convert.ToInt32(genelParaStr);
        if (genelParaInt < levelDeger)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        levelstr = "" + slider.value;
        levelint.text = levelstr;
        if(slider.value != 4)
        {
            levelDegerStr = "" + levelDeger;
            levelDegerint.text = levelDegerStr;
        }
        else
        {
            levelDegerint.transform.parent.GetChild(0).GetComponent<Image>().enabled = false;
            levelDegerint.GetComponent<Text>().enabled = false;
            gameObject.GetComponent<Button>().interactable = false;
        }
        switch (slider.value)
        {
            case 0:
                {
                    levelDeger = 300;
                    break;
                }
            case 1:
                {
                    levelDeger = 450;
                    break;
                }
            case 2:
                {
                    levelDeger = 600;
                    break;
                }
            case 3:
                {
                    levelDeger = 750;
                    break;
                }
            case 4:
                {
                    levelDeger = 1000;
                    break;
                }
        }
    }
    public void arttýr(int buton)
    {
        if(buton == 0)
        {

        }
        else if (buton == 1)
        {
            int maxDogruCanta = PlayerPrefs.GetInt("maxDogruCanta");
            int maxYanlisCanta = PlayerPrefs.GetInt("maxYanlisCanta");
            PlayerPrefs.SetInt("maxDogruCanta", maxDogruCanta + 2);
            PlayerPrefs.SetInt("maxYanlisCanta", maxYanlisCanta + 1);
        }
        else if (buton == 2)
        {

        }

        slider.value += 1;
    }
    
}
