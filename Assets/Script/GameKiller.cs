using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKiller : MonoBehaviour //attach on BoxKiller
{
    public GameObject[] HP;
    private int hp = 2;
    
    public void HPReduction()
    {
        hp -= 1;
        if (hp >= 0 && hp < HP.Length)
        {
            SetHPImage();
        }
        if (hp < 0) //check lose
        {
            End.self.EndLose();
        }
    }

    private void SetHPImage()
    {
        HP[hp].SetActive(false);
    }
}
