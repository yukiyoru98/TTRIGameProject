using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetroControl2 : MonoBehaviour
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
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rigid2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigid2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //rigid2D.AddForce(new Vector2(0, 1000f), ForceMode2D.Force);
                transform.position += new Vector3(0, -1f, 0);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Rotate(0, 0, -90);
            }
        }
    }

    //To win
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spawner2")
        {
            if (isFirstCollisionEnter == false)
            {
                FindObjectOfType<End2>().EndWin();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Create new tetros when colliding with Platform
        if (collision.gameObject.tag == "Platform2")
        {
            if (isFirstCollisionEnter == true)
            {
                // NEW : �Y�� �Ĥ@���I��(isFirstCollisionEnter == true)�A�h�i�� spawnNext() ���ͷs���
                FindObjectOfType<TetroSpawn2>().spawnNext();

                // NEW : �N flag �]�� flase�A�T�O���AĲ�o spawnNext() ��k
                isFirstCollisionEnter = false;

            }
        }
        if (collision.gameObject.tag == "Tetro2")
        {
            if (isFirstCollisionEnter == true)
            {
                // NEW : �Y�� �Ĥ@���I��(isFirstCollisionEnter == true)�A�h�i�� spawnNext() ���ͷs���
                FindObjectOfType<TetroSpawn2>().spawnNext();

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
                FindObjectOfType<TetroSpawn2>().spawnNext();

                // NEW : �N flag �]�� flase�A�T�O���AĲ�o spawnNext() ��k
                isFirstCollisionEnter = false;
            }
            Destroy(this.gameObject);
        }
    }
}

