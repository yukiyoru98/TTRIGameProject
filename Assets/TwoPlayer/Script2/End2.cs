using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End2 : MonoBehaviour
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
            GUI.color = new Color(1, 1, 1, 1); //�Q�n�H�X�ĪG���ܡA����Ȱ�(Time.timeScale = 0f;)�����A�M��o�̭ק令 GUI.color = new Color(1, 1, 1, alpha);
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
        //�H�U�O�쥻�]�w���Uesc�䤧��|�X�{����G
        //if (Input.GetKeyDown("escape"))
        //{
        //    windowSwitch = 1;
        //    alpha = 0; // Init Window Alpha Color
        //    Time.timeScale = 0f;
        //}
    }

    //If win is triggered from TetroControl/void OnTriggerEnter2D(Collider2D other)
    public void EndWin()
    {
        windowSwitch = 1;
        alpha = 0; // Init Window Alpha Color
        Time.timeScale = 0f;
    }

    void OnGUI()
    {
        if (windowSwitch == 1)
        {
            GUIAlphaColor_0_To_1();
            windowRect = GUI.Window(0, windowRect, WinWindow, "Quit Window");
        }
        else if (windowSwitch == 2)
        {
            GUIAlphaColor_0_To_1();
            windowRect = GUI.Window(0, windowRect, LoseWindow, "Quit Window");
        }

    }

    void WinWindow(int windowID)
    {
        GUI.Label(new Rect(175, 50, 300, 30), "���a1�ӧQ!");

        if (GUI.Button(new Rect(80, 110, 100, 20), "�^�쭺��"))
        {
            SceneManager.LoadScene("title");
            Time.timeScale = 1f;
        }
        if (GUI.Button(new Rect(220, 110, 100, 20), "�A���@�M"))
        {
            SceneManager.LoadScene("game2");
            Time.timeScale = 1f;
        }
        GUI.DragWindow();
    }

    //If lose is treiggered from TetroControl/void Update()/if (hp <= 0){}
    public void EndLose()
    {
        windowSwitch = 2;
        alpha = 0; // Init Window Alpha Color
        Time.timeScale = 0f;
    }

    void LoseWindow(int windowID)
    {
        GUI.Label(new Rect(183, 50, 300, 30), "����!");

        if (GUI.Button(new Rect(80, 110, 100, 20), "�^�쭺��"))
        {
            SceneManager.LoadScene("title");
            Time.timeScale = 1f;
        }
        if (GUI.Button(new Rect(220, 110, 100, 20), "�A���@�M"))
        {
            SceneManager.LoadScene("game");
            Time.timeScale = 1f;
        }
        GUI.DragWindow();
    }

}