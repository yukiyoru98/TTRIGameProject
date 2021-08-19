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
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigid2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigid2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //rigid2D.AddForce(new Vector2(0, 1000), ForceMode2D.Impulse);
            transform.position += new Vector3(0, -1f, 0);
        }
    }
}

//要一格一格地掉下來，還是連續？

//左右是加上加速度
//向下也是加上一個速度
//撞到地板之後就不能再移動了

