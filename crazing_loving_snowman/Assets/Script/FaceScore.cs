using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FaceScore : MonoBehaviour
{
    public Image Eye1;
    public Image Nose1;
    public Image Mouse1;
    public Image Eye2;
    public Image Nose2;
    public Image Mouse2;
    public Image Eye3;
    public Image Nose3;
    public Image Mouse3;
    public Image Eye4;
    public Image Nose4;
    public Image Mouse4;

    void Start()
    {
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


        if (eye1value == true)
        {
            Eye1.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Eye1.color = new Color(1, 1, 1, 0);
        }

        if (nose1value == true)
        {
            Nose1.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Nose1.color = new Color(1, 1, 1, 0);
        }

        if (mouse1value == true)
        {
            Mouse1.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Mouse1.color = new Color(1, 1, 1, 0);
        }

        if (eye2value == true)
        {
            Eye2.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Eye2.color = new Color(1, 1, 1, 0);
        }

        if (nose2value == true)
        {
            Nose2.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Nose2.color = new Color(1, 1, 1, 0);
        }

        if (mouse2value == true)
        {
            Mouse2.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Mouse2.color = new Color(1, 1, 1, 0);
        }

        if (eye3value == true)
        {
            Eye3.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Eye3.color = new Color(1, 1, 1, 0);
        }

        if (nose3value == true)
        {
            Nose3.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Nose3.color = new Color(1, 1, 1, 0);
        }

        if (mouse3value == true)
        {
            Mouse3.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Mouse3.color = new Color(1, 1, 1, 0);
        }
        if (eye4value == true)
        {
            Eye4.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Eye4.color = new Color(1, 1, 1, 0);
        }

        if (nose4value == true)
        {
            Nose4.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Nose4.color = new Color(1, 1, 1, 0);
        }

        if (mouse4value == true)
        {
            Mouse4.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Mouse4.color = new Color(1, 1, 1, 0);
        }
    }

    // Update is called once per frame
    
}
