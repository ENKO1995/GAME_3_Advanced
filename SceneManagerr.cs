using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerr : MonoBehaviour
{
    
    public Canvas Info;
    bool isActive= false;
    private void Update()
    {
        InfoScreen();
        SceneChanger();
    }
    private void SceneChanger()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextScene();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousScene();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    private void PreviousScene()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void NextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex < 2)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
    private void InfoScreen()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {


            if (isActive == false)
            {
                Info.gameObject.SetActive(true);
                isActive = true;
                Debug.Log(isActive);
            }
            else
            {
                Info.gameObject.SetActive(false);
                isActive = false;
                Debug.Log(isActive);

            }

        }
    }
}
