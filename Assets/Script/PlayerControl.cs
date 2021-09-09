using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour //Handle Input & win
{
    public TetroControl tetroControl;
    public WeightControl weightControl;
    public TetroSpawn tetroSpawn;
    public GameKiller gameKiller;
    [SerializeField]
    int player = 0;
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
            tetroControl.RotateTetro();
        }
        if (Input.GetKeyDown(down_key))
        {
            tetroControl.DropTetro();
        }
        if (Input.GetKey(left_key))
        {
            weightControl.GoLeft();
        }
        if (Input.GetKey(right_key))
        {
            weightControl.GoRight();
        }
    }
    
    public void Win()
    {
        End.self.EndWin(player);
    }
}
