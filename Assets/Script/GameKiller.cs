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
        if (hp == 2)
        {
            Destroy(GameObject.FindWithTag("healthpoint2"));
        }
        if (hp == 1)
        {
            Destroy(GameObject.FindWithTag("healthpoint1"));
        }
    }

    // Kill the tetros and deduce the blood
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tetro")
        {
            hp --;
        }
    }
}
