using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager: MonoBehaviour
{
    public Cube[] cube;             // масив ігрових об'єктів із цифрами
    public NumberCell[] triggers;   // масив ігрових елементів, в яких містяться номер правильного квадрату 
    public GameObject winPanel;
    public bool isWin;
    public GameObject view;
    public GameObject view2;

    // перевірка умови для проходження рівня
    public void win()
    {
        for (int i = 0; i < cube.Length; i++)
        {
            if (cube[i].number != cube[i].numberCell)
            {
                return;
            }
        }
        winPanel.SetActive(true);
        isWin = true;
    }
    // Перевіряє чи головоломка вирішена
    // та обробляє натискання на визначені клавіші.
    public void Update()
    {
        if (isWin)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("menu", LoadSceneMode.Single);
            }
        }
        // повернення на сцену головного меню
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }
        // вирішення головоломки
        if (Input.GetKeyDown(KeyCode.R))
        {
            this.Solve();
        }
        // зміна камери для огляду поля
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeCamera();

        }
    }

    //метод що міняє вигляд на сцену з різних камер
    public void ChangeCamera()
    {
        GameObject temp = new GameObject();
        temp.transform.position = view.transform.position;
        temp.transform.rotation = view.transform.rotation;
        view.transform.position = view2.transform.position;
        view.transform.rotation = view2.transform.rotation;
        view2.transform.position = temp.transform.position;
        view2.transform.rotation = temp.transform.rotation;
        Destroy(temp);
    }

    // вирішує ігровий рівень залишаючи ише останній хід для гравця.
    public void Solve()
    {
        for (int i =0; i < cube.Length; i++)
        {
            if (i != cube.Length-1)
                cube[i].transform.position = triggers[i].transform.position;
            else
            {
                cube[i].transform.position = triggers[i+1].transform.position;
            }
        }
    }


}
