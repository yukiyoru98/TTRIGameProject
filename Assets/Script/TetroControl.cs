using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetroControl : MonoBehaviour //attached on Player
{
    PlayerControl player; //宣告一個位子拿來放玩家的PlayerControl (在Unity的Inspector裡面手動拉)，位子名稱叫player
    private Tetro current_tetro;  //宣告一個位子拿來放當前正在操控的Tetro，位子名稱叫current_tetro
    private float base_force = 3f; //預設AddForce的基本力，要再 乘以weight 才是給方塊的力

    private void OnEnable() //當掛著這個腳本的GameObject 在遊戲中啟用時(就是GameObject是Active的時候)
    {
        player = GetComponent<PlayerControl>(); //從這個GameObject身上找到PlayerControl的腳本，並用player位子來接它
        player.weightControl.OnChangeWeightEvent += MoveTetro; //讓MoveTetro這個function訂閱player的weightControl的OnChangeWeightEvent
        //這樣只要weight改變時，引發OnChangeWeightEvent，那麼MoveTetro就會自動地去叫方塊移動
    }

    private void Start()
    {
        SpawnNext(); //遊戲開始時，生成一個方塊
    }
    
    public void MoveTetro(float weight) //invoked by WeightControl-OnChangeWeightEvent(剛剛在OnEnable有訂閱了) ，會收到weight為參數
    {//左右移動current_tetro(當前的Tetro)

        float force_x = base_force * weight; //基本力乘以weight = 真正要給tetro的force_x //weight可能是往左或往右
        current_tetro.Move(force_x); //呼叫current_tetro的Move，叫current_tetro根據這個force_x去移動
    }

    public void RotateTetro() //called by PlayerControl-GetKeyDown(up_key)
    {//旋轉current_tetro(當前的Tetro)

        current_tetro.Rotate(); //呼叫current_tetro的Rotate
    }

    public void DropTetro()//called by PlayerControl-GetKeyDown(up_key)
    {//往下掉current_tetro(當前的Tetro)

        current_tetro.Drop(); // 呼叫current_tetro的Drop
    }

    private void SpawnNext() //產生新的方塊，不再理之前的方塊
    {
        current_tetro = player.tetroSpawn.spawnNext(); //呼叫player的tetroSpawn的spawnNext，spawnNext回傳一個新的Tetro，用current_tetro來接它
        //訂閱這個新方塊的各種碰撞事件
        current_tetro.OnHitBoxKillerEvent += HitBoxKiller; //讓HitBoxKiller這個function訂閱current_tetro的OnHitBoxKillerEvent
        current_tetro.OnHitGoalEvent += HitGoal; //讓HitGoal這個function訂閱current_tetro的OnHitGoalEvent
        current_tetro.OnLandEvent += Land; //讓Land這個function訂閱current_tetro的OnLandEvent
        player.weightControl.ResetWeight(); //呼叫player的weightControl的ResetWeight，來重設weight為0
    }

    private void Land(Tetro t) //invoked by Tetro-OnLandEvent，會收到t為參數，代表t降落了
    {
        if (t == current_tetro) //如果invoked這個function的t就是玩家當前正在操控的tetro
        {
            SpawnNext(); //生下一個
            t.OnLandEvent -= Land; //只需在第一次land時SpawnNext，所以可以unsubscribe了，之後這個方塊再發生OnLaneEvent也不用管
        }
    }

    private void HitBoxKiller(Tetro t) //invoked by Tetro-OnHitBoxKillerEvent，會收到t為參數，代表t碰到boxKiller了
    {
        if (player.gameKiller != null) player.gameKiller.HPReduction(); //如果player的gameKiller存在的話就呼叫player的gameKiller的HPReduction，進行扣血的動作
        if (t == current_tetro) SpawnNext();//如果invoked這個function的t就是玩家當前正在操控的tetro，就生下一個
    }
    
    private void HitGoal(Tetro t) //invoked by Tetro-OnHitBoxKillerEvent，會收到t為參數，代表t碰到Goal了
    {
        player.Win(); //呼叫player的Win，進行獲勝的動作
    }
}



//在按住左右鍵的時候沒辦法按其它按鍵
//方塊如果在旋轉或下降時太靠近平台，有可能會卡住
//方塊如果兩個一起接觸boxkiller的話，會有重複扣血導致愛心無法正確顯示的問題
//如果遊戲失敗結束後，選擇重新玩的話，方塊會停在空中而且無法左右程動


//如果要access GameKiller的某個function的話，可以使用 FindObjectOfType<GameKiller>().HPDeduction(); 但要記得在該檔案中新增public void HPDeduction()的function
