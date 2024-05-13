using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //butona bas�ld���nda sahne y�kler.
    }

    public void QuitGame()
    {
        Debug.Log("Oyunu Kapattin!");
        Application.Quit();

    }



}
