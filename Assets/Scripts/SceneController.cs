using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour 
{

    [SerializeField] private GameObject Player;
    [SerializeField] private ParticleSystem Appearance;


    private GameObject _player;
    private ParticleSystem _appearance;


    public void Start()
    {

        LoadController.OnLoad += CurrentLevel;

        if (_player == null) //Если игрока нет, создаём его.
        {
            StartCoroutine(Begin());
        }
    }
    private void CurrentLevel(string nameLevel)
    {
        PlayerPrefs.SetString("CurrenLevel", nameLevel);
        PlayerPrefs.Save();
    }

    private IEnumerator Begin() 
    {

        yield return new WaitForSeconds(1f);  //Спустя 1 секунду появляется эффект.

        _appearance = Instantiate(Appearance) as ParticleSystem;

        _player = Instantiate(Player) as GameObject;

        _appearance.transform.position = _player.transform.position;

        yield return new WaitForSeconds(1f);  //Спустя ещё 3 секунды сам игрок.

        _player.SetActive(true);

        Destroy(_appearance);
        
    }

    private void OnDestroy()
    {
        LoadController.OnLoad -= CurrentLevel;
    }

}
