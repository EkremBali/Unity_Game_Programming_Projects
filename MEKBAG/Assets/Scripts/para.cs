using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class para : MonoBehaviour
{
    public Text paraStr;
    public int paraInt;
    public Text[] levelDeger;
    string levelDegerStr;
    int levelDegerInt;
    public Slider[] sliderDeger;

    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject FXOn;
    public GameObject FXOff;

    int music;
    int fx;
    void Start()
    {
        
        
        if (!PlayerPrefs.HasKey("hepGelirrr"))
        {
            Debug.Log("girdi");
            paraInt = 10000;
            PlayerPrefs.SetInt("hepPara", paraInt);
            PlayerPrefs.SetInt("hepGelirrr", paraInt);

        }
        else
        {
            
            paraInt = PlayerPrefs.GetInt("hepPara");

            sliderDeger[0].value = PlayerPrefs.GetFloat("slider0");
            sliderDeger[1].value = PlayerPrefs.GetFloat("slider1");
            sliderDeger[2].value = PlayerPrefs.GetFloat("slider2");
            sliderDeger[3].value = PlayerPrefs.GetFloat("slider3");
            
            music= PlayerPrefs.GetInt("music");
            fx=PlayerPrefs.GetInt("fx");

            if (music == 0)
            {
                musicOn.SetActive(true);
                musicOff.SetActive(false);
            }
            else
            {
                musicOn.SetActive(false);
                musicOff.SetActive(true);
            }
            if(fx == 0)
            {
                FXOn.SetActive(true);
                FXOff.SetActive(false);
            }
            else
            {
                FXOn.SetActive(false);
                FXOff.SetActive(true);
            }
        }
        

    }

    void Update()
    {
        paraStr.text = "" + paraInt;
        
    }
    public void paracik(int a)
    {
        levelDegerStr = levelDeger[a].text;
        levelDegerInt = Convert.ToInt32(levelDegerStr);

        if (paraInt >= levelDegerInt)
        {
            paraInt -= levelDegerInt;
        }
        PlayerPrefs.SetInt("hepPara", paraInt);
    }
    public void exitYapma()
    {
        PlayerPrefs.DeleteAll();
    }
    public void levelHafizaTutma()
    {
        PlayerPrefs.SetFloat("slider0", sliderDeger[0].value);
        PlayerPrefs.SetFloat("slider1", sliderDeger[1].value);
        PlayerPrefs.SetFloat("slider2", sliderDeger[2].value);
        PlayerPrefs.SetFloat("slider3", sliderDeger[3].value);
    }
    public void musicTutma(int b)
    {
        PlayerPrefs.SetInt("music", b);
    }
    public void fxTutma(int c)
    {
        PlayerPrefs.SetInt("fx", c);
    }
}
