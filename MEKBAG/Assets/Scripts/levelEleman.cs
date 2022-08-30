using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class levelEleman : MonoBehaviour
{
    public Slider slider;
    public Slider slider2;
    public Text levelint;
    string levelstr;
    public int levelDeger = 300;
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
        genelParaInt = Convert.ToInt32(genelParaStr);
        if (slider2.value == slider.value|| genelParaInt < levelDeger)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        slider.maxValue = slider2.value;
        levelstr = "" + slider.value;
        levelint.text = levelstr;
        if (slider.value != 4)
        {
            levelDegerStr = "" + levelDeger;
            levelDegerint.text = levelDegerStr;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
            levelDegerint.transform.parent.GetChild(0).GetComponent<Image>().enabled = false;
            levelDegerint.GetComponent<Text>().enabled = false;
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
    public void arttýr()
    {
        slider.value += 1;
    }
}
