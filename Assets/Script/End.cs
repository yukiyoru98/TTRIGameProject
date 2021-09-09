using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public static End self; //建立singleton，名稱為self
    int _player = 0; //記錄誰贏了 //通常習慣上會用底線_來當作名稱的第一個字來表示這個變數是private的
    
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
        self = this;
        windowRect = new Rect(
            (Screen.width - windowWidth) / 2,
            (Screen.height - windowHight) / 2,
            windowWidth,
            windowHight);
    }

    void Update()
    {
        //以下是原本設定按下esc鍵之後會出現的後果
        //if (Input.GetKeyDown("escape"))
        //{
        //    windowSwitch = 1;
        //    alpha = 0; // Init Window Alpha Color
        //    Time.timeScale = 0f;
        //}
    }


    public void EndWin(int player) //called by PlayerControl-Win, 傳入player(玩家編號)
    {
        _player = player; //把player編號記錄下來，存在End自己的_player裡
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
        } else if (windowSwitch == 2)
        {
            GUIAlphaColor_0_To_1();
            windowRect = GUI.Window(0, windowRect, LoseWindow, "Quit Window");
        }

    }

    void WinWindow(int windowID)
    {
        if (_player != 0) //檢查_player不是0，代表玩家有編號之分（1或2），所以是雙人模式
        {
            GUI.Label(new Rect(175, 50, 300, 30), $"玩家{_player}勝利!"); //在視窗上顯示玩家編號
        }
        else //_player是0，代表玩家沒有編號之分，所以是單人模式
        {
            GUI.Label(new Rect(183, 50, 300, 30), "勝利!");  //在視窗上不須顯示編號
        }

        if (GUI.Button(new Rect(80, 110, 100, 20), "回到首頁"))
        {
            SceneManager.LoadScene("title");
            Time.timeScale = 1f;
        }
        if (GUI.Button(new Rect(220, 110, 100, 20), "再玩一遍"))
        {
            //SceneManager.LoadScene("game");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //直接重新load現在的這個scene //SceneManager.GetActiveScene().name就是現在這個scene的名稱
            Time.timeScale = 1f;
        }
        GUI.DragWindow();
    }


    public void EndLose() //called by GameKiller when hp < 0
    {
        windowSwitch = 2;
        alpha = 0; // Init Window Alpha Color
        Time.timeScale = 0f;
    }

    void LoseWindow(int windowID)
    {
        GUI.Label(new Rect(183, 50, 300, 30), "失敗!");

        if (GUI.Button(new Rect(80, 110, 100, 20), "回到首頁"))
        {
            SceneManager.LoadScene("title");
            Time.timeScale = 1f;
        }
        if (GUI.Button(new Rect(220, 110, 100, 20), "再玩一遍"))
        {
            //SceneManager.LoadScene("game");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //直接重新load現在的這個scene //SceneManager.GetActiveScene().name就是現在這個scene的名稱
            Time.timeScale = 1f;
        }
        GUI.DragWindow();
    }

}