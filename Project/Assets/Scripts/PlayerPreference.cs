using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreference : MonoBehaviour
{
    //static variables to be called in other scripts for reference and to be adjusted via loot
    static public int sixCountMax = 0;
    static public int eightCountMax = 0;
    static public int twelveCountMax = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SixCountMax"))
        {
            sixCountMax = PlayerPrefs.GetInt("SixCountMax");
        }
        PlayerPrefs.SetInt("SixCountMax", sixCountMax);

        if (PlayerPrefs.HasKey("EightCountMax"))
        {
            eightCountMax = PlayerPrefs.GetInt("EightCountMax");
        }
        PlayerPrefs.SetInt("EightCountMax", eightCountMax);

        if (PlayerPrefs.HasKey("TwelveCountMax"))
        {
            sixCountMax = PlayerPrefs.GetInt("TwelveCountMax");
        }
        PlayerPrefs.SetInt("TwelveCountMax", twelveCountMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (sixCountMax != PlayerPrefs.GetInt("SixCountMax"))
        {
            PlayerPrefs.SetInt("SixCountMax", sixCountMax);
        }

        if (eightCountMax != PlayerPrefs.GetInt("EightCountMax"))
        {
            PlayerPrefs.SetInt("EightCountMax", eightCountMax);
        }

        if (twelveCountMax != PlayerPrefs.GetInt("TwelveCountMax"))
        {
            PlayerPrefs.SetInt("TwelveCountMax", twelveCountMax);
        }
    }
}
