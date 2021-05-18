using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadController : MonoBehaviour
{

    [SerializeField] private Image LevelPassed;
    [SerializeField] private Image LevelFailed;
    [SerializeField] private Image GamePassed;

    [SerializeField] private Button CatchButton;

    public static Action<string> OnLoad = delegate { };

    [SerializeField] private string nextLevel;

    private string currentLevel;  

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Move.OnEnd += End;
        FieldOfView.OnCatch += Catch;

        currentLevel = SceneManager.GetActiveScene().name;
        OnLoad(currentLevel);
    }

    private void End() 
    {
        StartCoroutine(Begin());
    }

    private void Catch() 
    {
        CatchButton.transform.LeanScale(Vector2.one, 0.3f).setEaseInBack();
        LevelFailed.gameObject.SetActive(true);
        LevelFailed.transform.LeanMoveLocalY(0, 3f);
    }

    public void Anew() 
    {
        SceneManager.LoadScene(currentLevel);

    }

    private IEnumerator Begin()
    {
        if (currentLevel != "Last")
        {
            LevelPassed.gameObject.SetActive(true);
            LevelPassed.transform.LeanMoveLocalY(0, 3f);

            yield return new WaitForSeconds(3f);

            SceneManager.LoadScene(nextLevel);
        }
        else 
        {
            GamePassed.gameObject.SetActive(true);
            GamePassed.transform.LeanMoveLocalY(0, 3f);

            yield return new WaitForSeconds(3f);

            SceneManager.LoadScene("Menu");

        }
    }

    private void OnDestroy()
    {
        Move.OnEnd -= End;
        FieldOfView.OnCatch -= Catch;
    }
}
