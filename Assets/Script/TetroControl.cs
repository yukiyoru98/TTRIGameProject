using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetroControl : MonoBehaviour
{

    public float speed = 1f;
    public Rigidbody2D rigid2D;

    // NEW : 設定一個 flag，用來確認當前方塊是否 "第一次" 發生 OnCollisionEnter
    private bool isFirstCollisionEnter = true;

    // Start is called before the first frame update
    void Start()
    {
        // NEW : 初始化 設為 true
        isFirstCollisionEnter = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirstCollisionEnter == true)
        {
                if (Input.GetKey(KeyCode.LeftArrow))
            {
                rigid2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rigid2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //rigid2D.AddForce(new Vector2(0, 1000f), ForceMode2D.Force);
                transform.position += new Vector3(0, -1f, 0);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Rotate(0, 0, -90);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spawner")
        {
            if (isFirstCollisionEnter == false)
            {
                print("Win!");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Create new tetros when colliding with Platform
        if (collision.gameObject.tag == "Platform")
        {
            if (isFirstCollisionEnter == true)
            {
                // NEW : 若為 第一次碰撞(isFirstCollisionEnter == true)，則進行 spawnNext() 產生新方塊
                FindObjectOfType<TetroSpawn>().spawnNext();

                // NEW : 將 flag 設為 flase，確保不再觸發 spawnNext() 方法
                isFirstCollisionEnter = false;
            }
        }
        if (collision.gameObject.tag == "Tetro")
        {
            if (isFirstCollisionEnter == true)
            {
                // NEW : 若為 第一次碰撞(isFirstCollisionEnter == true)，則進行 spawnNext() 產生新方塊
                FindObjectOfType<TetroSpawn>().spawnNext();

                // NEW : 將 flag 設為 flase，確保不再觸發 spawnNext() 方法
                isFirstCollisionEnter = false;
            }
        }
        // Self-destroyed when colliding with Boxkiller
        if (collision.gameObject.tag == "BoxKiller")
        {
            if (isFirstCollisionEnter == true)
            {
                Destroy(this.gameObject);

                // NEW : 若為 第一次碰撞(isFirstCollisionEnter == true)，則進行 spawnNext() 產生新方塊
                FindObjectOfType<TetroSpawn>().spawnNext();

                // NEW : 將 flag 設為 flase，確保不再觸發 spawnNext() 方法
                isFirstCollisionEnter = false;
            } 
            Destroy(this.gameObject);
        }
    }
}


//如果方塊同時(1)接觸到方塊(2)接觸到頂點，則判定勝利。但是目前系統似乎是不理我，不清楚為什麼？

//在按住左右鍵的時候沒辦法按其它按鍵
//方塊如果在旋轉或下降時太靠近平台，有可能會卡住
//方塊如果兩個一起接觸boxkiller的話，會有重複扣血導致愛心無法正確顯示的問題


//如果要access GameKiller的話，可以使用 FindObjectOfType<GameKiller>().HPDeduction(); 但要記得在該檔案中新增HPDeduction()的function
