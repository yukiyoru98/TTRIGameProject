using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour //Handle Input & win
{
    //這些只是位子，要在Inspector中把對應的人放上去，因此每個玩家的PlayerControl中可以對應不同的人
    public TetroControl tetroControl; //給TetroControl的位子，名稱為tetroControl
    public WeightControl weightControl; //給WeightControl的位子，名稱為tetroControl
    public TetroSpawn tetroSpawn; //給TetroSpawn的位子，名稱為tetroSpawn
    public GameKiller gameKiller; //給GameKiller的位子，名稱為gameKiller

    [SerializeField]
    int player = 0; //玩家編號，可在Inspector中手動設定

    //上下左右的對應按鍵，可在Inspector中手動設定
    [SerializeField]
    private KeyCode up_key = KeyCode.UpArrow;
    [SerializeField]
    private KeyCode right_key = KeyCode.RightArrow;
    [SerializeField]
    private KeyCode left_key = KeyCode.LeftArrow;
    [SerializeField]
    private KeyCode down_key = KeyCode.DownArrow;

    private void Update()
    {
        if (Input.GetKeyDown(up_key))
        {
            tetroControl.RotateTetro(); //呼叫tetroControl的RotateTetro //意思就是叫坐在tetroControl位子上的人去做它的RotateTetro
        }
        if (Input.GetKeyDown(down_key))
        {
            tetroControl.DropTetro(); //叫坐在tetroControl位子上的人去做它的DropTetro
        }
        if (Input.GetKey(left_key))
        {
            weightControl.GoLeft(); //叫坐在weightControl位子上的人去做它的GoLeft
        }
        if (Input.GetKey(right_key))
        {
            weightControl.GoRight(); //叫坐在weightControl位子上的人去做它的GoRight
        }
    }
    
    public void Win()
    {
        End.self.EndWin(player); //呼叫End的self的EndWin，並傳入player編號，代表獲勝的是誰
    }
}
