using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WeightControl : MonoBehaviour
{
    public RectTransform bar_image;
    public RectTransform weight_image; //UI的方形圖示
    private float step = 0.02f; //每按一下箭頭，weight的變化量為0.02f
    private float weight_value = 0; //weight起始為0
    private Vector2 weight_range = new Vector2(-1f, 1f); //weight最小為-1(左傾到底)，最大為1(右傾到底)
    private float ui_step;  //每增加一單位的weight，weight_image在bar上應該移動多少單位

    public event Action<float> OnChangeWeightEvent; //weight改變的事件，會傳給訂閱者一個float，告訴對方現在的weight是多少
    private void OnEnable()
    {
        OnChangeWeightEvent += SetWeightBar; //讓SetWeightBar這個function訂閱player的weightControl的OnChangeWeightEvent
        //這樣只要weight改變時，引發OnChangeWeightEvent，那麼SetWeightBar就會自動地去調整UI
    }
    private void Start()
    {
        //一開始就先計算好每增加一單位的weight，weight_image在bar上應該移動多少單位
        ui_step = bar_image.rect.width / (weight_range.y - weight_range.x); //bar的總長 除以 weight的範圍大小(最大值-最小值)
    }
    
    public void GoLeft() //called by PlayerControl-GetKey(left_key)
    {
        ChangeWeight(weight_value - step); //往左為負，所以將weight改變為weight - step
    }

    public void GoRight() //called by PlayerControl-GetKey(right_key)
    {
        ChangeWeight(weight_value + step); //往右為正，所以將weight改變為weight + step
    }

    public void ChangeWeight(float w) //之後串接壓力感測平台的話，可以直接呼叫這個function來設定weight
    {
        weight_value = Mathf.Clamp(w, weight_range.x, weight_range.y); //新傳入的w值必須在最大最小值之間
        /*
         * Mathf.Clamp(a, b, c)會把a限制在b,c之間
         * 也就是檢查: a如果小於最小值b，就讓a=b就好，如果a > 最大值c 那就讓a = c
         */

        //Debug.Log($"change weight:{weight_value}");
        OnChangeWeightEvent?.Invoke(weight_value); //引發weight改變的事件，通知訂閱者新的weight是多少(weight_value)
    }

    public void ResetWeight()  //重置weight為0
    {
        //Debug.Log("ResetWeight");
        ChangeWeight(0);
    }

    void SetWeightBar(float w) //invoked by OnChangeWeightEvent //移動UI上的weight image的x座標
    { //接收w作為weight
        float position_x = w * ui_step;//新的x座標為 w * ui_step
        float position_y = weight_image.anchoredPosition.y;//新的y座標為 weight image目前的y座標(維持不變)
        Vector2 new_position = new Vector2(position_x, position_y); //將新的x和y座標合起來，變成一個新的2維向量
        weight_image.anchoredPosition = new_position; //設定weight_image的新位置

        /*P.S.因為UI物件的座標的資料型態是Vector2，無法一次只更動xy其中一個方向的座標
         * 沒有 " weight_image.anchoredPosition.x = position_x " 這種用法
         * 必須直接給它一個新的向量，所以才要這麼搞工
         */
    }
}
