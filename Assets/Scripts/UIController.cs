using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField] private Button NewGameButton;
    [SerializeField] private Button ContinueGameButton;
    [SerializeField] private Button MenuButton;

    public void SetColor(string colorPlayer)
    {
        PlayerColor.GamePlayerColor = colorPlayer;
    }

    public void NewGame()
    {
        NewGameButton.transform.LeanScale(Vector2.one, 0.3f).setEaseInBack();
        SceneManager.LoadScene("Level1");
    }

    public void ContinueGame() 
    {
        NewGameButton.transform.LeanScale(Vector2.one, 0.3f).setEaseInBack();
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrenLevel", "Level1"));
    }
}
