using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public static string GamePlayerColor
    {
        get => PlayerPrefs.GetString("GamePlayerColor", "White");
        set
        {
            PlayerPrefs.SetString("GamePlayerColor", value);
            PlayerPrefs.Save();
        }
    }
}
