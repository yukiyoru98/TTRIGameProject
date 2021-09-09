using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKiller : MonoBehaviour //attach on BoxKiller
{
    public GameObject[] HP; //愛心們 //2個愛心的話，他們在array中的index(編號)分別為0,1
    private int hp = 2; //從2開始扣，到-1時就lose，共可扣3次
    
    public void HPReduction()// called by TetroControl-HitBoxKiller
    {
        hp -= 1;
        if (hp >= 0 && hp < HP.Length) //如果0 <= hp < 愛心數量 
        {//雖然我們知道hp從2開始，不會比愛心數量多，但養成好習慣，在使用array時切記要檢查有沒有在array的範圍內
            
            SetHPImage();
        }
        
        if (hp < 0) //如果hp扣第三次變成-1了
        {
            End.self.EndLose(); //呼叫End的self的EndLose
        }
    }

    private void SetHPImage()
    {
        /*
       *第1次扣血時hp會從2變1，所以就關掉HP[1]的愛心
       *第2次扣血時hp會從1變0，所以就關掉HP[0]的愛心
       *第3次扣血時hp會從0變-1，已經沒有愛心了所以不用關
       */
        HP[hp].SetActive(false);
    }
}
