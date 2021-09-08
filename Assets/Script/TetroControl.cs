using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetroControl : MonoBehaviour //attached on Player
{
    PlayerControl player;
    private Tetro current_tetro;
    private float base_force = 3f;

    private void OnEnable()
    {
        player = GetComponent<PlayerControl>();
        player.weightDistributor.OnChangeWeightEvent += MoveTetro;
    }

    private void Start()
    {
        SpawnNext();
    }
    
    public void MoveTetro(float weight)
    {
        //把weight轉換成tetro的force，並傳給tetro
        float force_x = base_force * weight;
        current_tetro.Move(force_x);
    }

    public void RotateTetro()
    {
        current_tetro.Rotate();
    }

    public void DropTetro()
    {
        current_tetro.Drop();
    }

    private void SpawnNext() 
    {
        current_tetro = player.tetroSpawn.spawnNext();
        //subscribe
        current_tetro.OnHitBoxKillerEvent += HitBoxKiller;
        current_tetro.OnHitGoalEvent += HitGoal;
        current_tetro.OnLandEvent += Land;
        player.weightDistributor.ResetWeight();
    }

    private void Land(Tetro t)
    {
        if (t == current_tetro) //如果call這個function的是玩家當前正在操控的tetro
        {
            SpawnNext(); //生下一個
            t.OnLandEvent -= Land; //只需在第一次land時SpawnNext，所以可以unsubscribe了
        }
    }

    private void HitBoxKiller(Tetro t)
    {
        if (player.gameKiller) player.gameKiller.HPReduction();
        if (t == current_tetro) SpawnNext();//如果call這個function的是玩家當前正在操控的tetro，就生下一個
    }
    
    private void HitGoal(Tetro t)
    {
        player.Win();
    }
}



//在按住左右鍵的時候沒辦法按其它按鍵
//方塊如果在旋轉或下降時太靠近平台，有可能會卡住
//方塊如果兩個一起接觸boxkiller的話，會有重複扣血導致愛心無法正確顯示的問題
//如果遊戲失敗結束後，選擇重新玩的話，方塊會停在空中而且無法左右程動


//如果要access GameKiller的某個function的話，可以使用 FindObjectOfType<GameKiller>().HPDeduction(); 但要記得在該檔案中新增public void HPDeduction()的function
