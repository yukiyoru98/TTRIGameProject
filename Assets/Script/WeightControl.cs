using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WeightControl : MonoBehaviour
{
    public RectTransform bar_image;
    public RectTransform weight_image;
    private float step = 0.02f;
    private float weight_value = 0;
    private Vector2 weight_range = new Vector2(-1f, 1f);
    private float ui_step;

    public event Action<float> OnChangeWeightEvent;
    private void OnEnable()
    {
        OnChangeWeightEvent += SetWeightBar;
    }
    private void Start()
    {
        //�p��C��step����UI��weight image�����ʶZ��
        ui_step = bar_image.rect.width / (weight_range.y - weight_range.x);
    }
    
    public void GoLeft()
    {
        ChangeWeight(weight_value - step);
    }

    public void GoRight()
    {
        ChangeWeight(weight_value + step);
    }

    public void ChangeWeight(float w) //����걵���O�P�����x���ܡA�i�H�����I�s�o��function�ӳ]�wweight
    {
        weight_value = Mathf.Clamp(w, weight_range.x, weight_range.y);
        //Debug.Log($"change weight:{weight_value}");
        OnChangeWeightEvent?.Invoke(weight_value);
    }

    public void ResetWeight() 
    {
        //Debug.Log("ResetWeight");
        ChangeWeight(0);
    }

    void SetWeightBar(float w) //����UI�W��weight image
    {
        weight_image.anchoredPosition = new Vector2( w * ui_step, weight_image.anchoredPosition.y );
        //Debug.Log($"SetWeightBar:{weight_image.anchoredPosition}");
    }
}
