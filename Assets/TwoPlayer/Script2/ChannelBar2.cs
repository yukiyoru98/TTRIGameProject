using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelBar2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            this.transform.localScale += new Vector3(0, 0.02f, 0);
        }
        if (this.transform.localScale == new Vector3(this.transform.localScale.x, 1, this.transform.localScale.z))
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, 0f, this.transform.localScale.z);
        }
    }
}
