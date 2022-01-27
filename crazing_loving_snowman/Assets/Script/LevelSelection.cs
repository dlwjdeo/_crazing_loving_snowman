using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    public GameObject Eye1;
    public GameObject Nose1;
    public GameObject Mouse1;
    public GameObject Eye2;
    public GameObject Nose2;
    public GameObject Mouse2;
    public GameObject Eye3;
    public GameObject Nose3;
    public GameObject Mouse3;
    public GameObject Eye4;
    public GameObject Nose4;
    public GameObject Mouse4;
    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2); 
        bool eye1value = System.Convert.ToBoolean(PlayerPrefs.GetInt("eye1"));
        bool nose1value = System.Convert.ToBoolean(PlayerPrefs.GetInt("nose1"));
        bool mouse1value = System.Convert.ToBoolean(PlayerPrefs.GetInt("mouse1"));
        bool eye2value = System.Convert.ToBoolean(PlayerPrefs.GetInt("eye2"));
        bool nose2value = System.Convert.ToBoolean(PlayerPrefs.GetInt("nose2"));
        bool mouse2value = System.Convert.ToBoolean(PlayerPrefs.GetInt("mouse2"));
        bool eye3value = System.Convert.ToBoolean(PlayerPrefs.GetInt("eye3"));
        bool nose3value = System.Convert.ToBoolean(PlayerPrefs.GetInt("nose3"));
        bool mouse3value = System.Convert.ToBoolean(PlayerPrefs.GetInt("mouse3"));
        bool eye4value = System.Convert.ToBoolean(PlayerPrefs.GetInt("eye4"));
        bool nose4value = System.Convert.ToBoolean(PlayerPrefs.GetInt("nose4"));
        bool mouse4value = System.Convert.ToBoolean(PlayerPrefs.GetInt("mouse4"));

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                lvlButtons[i].interactable = false;
        }

        if(eye1value == true)
        {
            Eye1.SetActive(true);
        }
        else
        {
            Eye1.SetActive(false);
        }

        if (nose1value == true)
        {
            Nose1.SetActive(true);
        }
        else
        {
            Nose1.SetActive(false);
        }

        if (mouse1value == true)
        {
            Mouse1.SetActive(true);
        }
        else
        {
            Mouse1.SetActive(false);
        }

        if (eye2value == true)
        {
            Eye2.SetActive(true);
        }
        else
        {
            Eye2.SetActive(false);
        }

        if (nose2value == true)
        {
            Nose2.SetActive(true);
        }
        else
        {
            Nose2.SetActive(false);
        }

        if (mouse2value == true)
        {
            Mouse2.SetActive(true);
        }
        else
        {
            Mouse2.SetActive(false);
        }

        if (eye3value == true)
        {
            Eye3.SetActive(true);
        }
        else
        {
            Eye3.SetActive(false);
        }

        if (nose3value == true)
        {
            Nose3.SetActive(true);
        }
        else
        {
            Nose3.SetActive(false);
        }

        if (mouse3value == true)
        {
            Mouse3.SetActive(true);
        }
        else
        {
            Mouse3.SetActive(false);
        }
        if (eye4value == true)
        {
            Eye4.SetActive(true);
        }
        else
        {
            Eye4.SetActive(false);
        }

        if (nose4value == true)
        {
            Nose4.SetActive(true);
        }
        else
        {
            Nose4.SetActive(false);
        }

        if (mouse4value == true)
        {
            Mouse4.SetActive(true);
        }
        else
        {
            Mouse4.SetActive(false);
        }
        
    }

}
