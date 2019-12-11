using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// скрипт головного меню
public class Menu : MonoBehaviour
{

    // обробка вибору сцени рівня
    // кнопки 3х3, 4х4 та How To Play
    public void OnMouseUp(string SceneName)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }

    // обробка натискання кнопки "Exit"
    // вихід з гри
    public void ExitGame()
    {
        Application.Quit();
    }
}
