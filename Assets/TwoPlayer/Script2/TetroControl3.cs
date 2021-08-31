using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetroControl3 : MonoBehaviour
{

    public float speed = 1f;
    public Rigidbody2D rigid2D;

    // NEW : �]�w�@�� flag�A�ΨӽT�{��e����O�_ "�Ĥ@��" �o�� OnCollisionEnter
    private bool isFirstCollisionEnter = true;

    // Start is called before the first frame update
    void Start()
    {
        // NEW : ��l�� �]�� true
        isFirstCollisionEnter = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirstCollisionEnter == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rigid2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rigid2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                //rigid2D.AddForce(new Vector2(0, 1000f), ForceMode2D.Force);
                transform.position += new Vector3(0, -1f, 0);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.Rotate(0, 0, -90);
            }
        }
    }

    //To win
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spawner3")
        {
            if (isFirstCollisionEnter == false)
            {
                FindObjectOfType<End3>().EndWin();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Create new tetros when colliding with Platform
        if (collision.gameObject.tag == "Platform3")
        {
            if (isFirstCollisionEnter == true)
            {
                // NEW : �Y�� �Ĥ@���I��(isFirstCollisionEnter == true)�A�h�i�� spawnNext() ���ͷs���
                FindObjectOfType<TetroSpawn3>().spawnNext();

                // NEW : �N flag �]�� flase�A�T�O���AĲ�o spawnNext() ��k
                isFirstCollisionEnter = false;
            }
        }
        if (collision.gameObject.tag == "Tetro3")
        {
            if (isFirstCollisionEnter == true)
            {
                // NEW : �Y�� �Ĥ@���I��(isFirstCollisionEnter == true)�A�h�i�� spawnNext() ���ͷs���
                FindObjectOfType<TetroSpawn3>().spawnNext();

                // NEW : �N flag �]�� flase�A�T�O���AĲ�o spawnNext() ��k
                isFirstCollisionEnter = false;
            }
        }
        // Self-destroyed when colliding with Boxkiller
        if (collision.gameObject.tag == "BoxKiller")
        {
            if (isFirstCollisionEnter == true)
            {
                Destroy(this.gameObject);

                // NEW : �Y�� �Ĥ@���I��(isFirstCollisionEnter == true)�A�h�i�� spawnNext() ���ͷs���
                FindObjectOfType<TetroSpawn3>().spawnNext();

                // NEW : �N flag �]�� flase�A�T�O���AĲ�o spawnNext() ��k
                isFirstCollisionEnter = false;
            }
            Destroy(this.gameObject);
        }
    }
}

