using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLose : MonoBehaviour
{
    // public
    public int windowWidth = 400;
    public int windowHight = 150;

    // private
    Rect windowRect;
    int windowSwitch = 0;
    float alpha = 0;

    void GUIAlphaColor_0_To_1()
    {
        if (alpha < 1)
        {
            alpha += Time.deltaTime;
            GUI.color = new Color(1, 1, 1, 1); //想要淡出效果的話，先把暫停(Time.timeScale = 0f;)關掉，然後這裡修改成 GUI.color = new Color(1, 1, 1, alpha);
        }
    }

    // Init
    void Awake()
    {
        windowRect = new Rect(
            (Screen.width - windowWidth) / 2,
            (Screen.height - windowHight) / 2,
            windowWidth,
            windowHight);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            windowSwitch = 1;
            alpha = 0; // Init Window Alpha Color
            Time.timeScale = 0f;
        }
    }

    void OnGUI()
    {
        if (windowSwitch == 1)
        {
            GUIAlphaColor_0_To_1();
            windowRect = GUI.Window(0, windowRect, QuitWindow, "Quit Window");
        }
    }

    void QuitWindow(int windowID)
    {
        GUI.Label(new Rect(183, 50, 300, 30), "失敗!");

        if (GUI.Button(new Rect(80, 110, 100, 20), "回到首頁"))
        {
            SceneManager.LoadScene("title");
            Time.timeScale = 1f;
        }
        if (GUI.Button(new Rect(220, 110, 100, 20), "再玩一遍"))
        {
            SceneManager.LoadScene("game");
            Time.timeScale = 1f;
        }
        GUI.DragWindow();
    }

}