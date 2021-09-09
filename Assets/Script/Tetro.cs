using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tetro : MonoBehaviour //attached on each Tetro
{
    public Rigidbody2D rigid2D;
    public event Action<Tetro> OnLandEvent; //降落在platform或其他tetro上的事件
    public event Action<Tetro> OnHitBoxKillerEvent; //碰到BoxKiller的事件
    public event Action<Tetro> OnHitGoalEvent; //碰到BoxKiller的事件
    private bool _landed; //記錄是否已經降落platform或其他tetro上（必須已完成降落的情況下，碰到Goal才算勝利）
    
    public void Move(float force_x) //called by TetroControl-MoveTetro
    {
        rigid2D.AddForce(new Vector2(force_x, 0), ForceMode2D.Force);
        //Debug.Log($"velocity:{rigid2D.velocity}");
    }

    public void Rotate() //called by TetroControl-RotateTetro
    {
        transform.Rotate(0, 0, -90);
    }

    public void Drop() //called by TetroControl-Drop
    {
        transform.position += new Vector3(0, -1f, 0);
    }

    //To win
    void OnTriggerStay2D(Collider2D other) //用stay!
    {
        if (other.gameObject.tag == "Goal" && _landed)//已完成降落的情況下，碰到Goal才算勝利
        { 
            OnHitGoalEvent?.Invoke(this); //引發事件來通知訂閱者我碰到Goal了
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Self-destroyed when colliding with Boxkiller
        if (collision.gameObject.tag == "BoxKiller")
        {
            Destroy(this.gameObject);
            OnHitBoxKillerEvent?.Invoke(this); //引發事件來通知訂閱者我碰到BoxKiller了
        }
        else if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Tetro") {
            _landed = true; //記錄已經降落
            OnLandEvent?.Invoke(this); //引發事件來通知訂閱者我降落了
        }
    }
    
    /*之後可能需要??
    void CheckStable()
    {
    }
    */
}
