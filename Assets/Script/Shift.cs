using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour
{

    public float speed = 1000f;
    public Rigidbody2D rigid2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rigid2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //rigid2D.AddForce(new Vector2(0, 1000f), ForceMode2D.Force);
            transform.position += new Vector3(0, -1f, 0);
        }
    }
}

//要一格一格地掉下來，還是連續？

//向下也是加上一個速度
//旋轉、東西撞到地面或確定跌落之後就不能再動，而且要創造出新的方塊
