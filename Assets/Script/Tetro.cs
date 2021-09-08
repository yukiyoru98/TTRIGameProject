using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tetro : MonoBehaviour //attached on each Tetro
{
    public Rigidbody2D rigid2D;
    public event Action<Tetro> OnLandEvent; //降落在platform或其他tetro上
    public event Action<Tetro> OnHitBoxKillerEvent; //碰到BoxKiller
    public event Action<Tetro> OnHitGoalEvent; //碰到BoxKiller
    private bool _landed; //記錄是否已經降落platform或其他tetro上
    
    public void Move(float force_x)
    {
        rigid2D.AddForce(new Vector2(force_x, 0), ForceMode2D.Force);
        //Debug.Log($"velocity:{rigid2D.velocity}");
    }

    public void Rotate()
    {
        transform.Rotate(0, 0, -90);
    }

    public void Drop()
    {
        transform.position += new Vector3(0, -1f, 0);
    }

    //To win
    void OnTriggerStay2D(Collider2D other) //用stay!
    {
        if (other.gameObject.tag == "Goal" && _landed)
        { 
            OnHitGoalEvent?.Invoke(this);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Self-destroyed when colliding with Boxkiller
        if (collision.gameObject.tag == "BoxKiller")
        {
            Destroy(this.gameObject);
            OnHitBoxKillerEvent?.Invoke(this);
        }
        else if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Tetro") {
            _landed = true;
            OnLandEvent?.Invoke(this);
        }
    }
    
    /*之後可能需要??
    void CheckStable()
    {
    }
    */
}
