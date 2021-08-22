using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKiller : MonoBehaviour
{
    public int hp = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 2)
        {
            Destroy(GameObject.FindWithTag("healthpoint2"));
        }
        if (hp <= 1)
        {
            Destroy(GameObject.FindWithTag("healthpoint1"));
        }
        if (hp <= 0) //to lose
        {
            FindObjectOfType<End>().EndLose();
        }
    }

    // Health point deduction 方塊不規則形導致boxcollider有兩個以上，因此有時候會一次有兩個碰撞事件發生，導致血量直接2滴，不知道該怎麼解？

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tetro")
        {
            hp--;
        }
    }

    //public void HPDeduction()
    //{
    //    hp -= 1;
    //}
}
