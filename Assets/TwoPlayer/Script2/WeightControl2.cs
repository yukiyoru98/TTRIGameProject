using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightControl2 : MonoBehaviour
{
    //private float StartPosition = GameObject.GetComponent<Transform>().position;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position -= new Vector3(0.02f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += new Vector3(0.02f, 0, 0);
        }
    }
}
