using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetroSpawn : MonoBehaviour //attached on Spawner
{
    // Groups
    public GameObject[] groups;

    public Tetro spawnNext() //生出一個新tetro，並回傳給呼叫這個function的人
    {
        //Debug.Log("spawn");
        // Random Index
        int i = Random.Range(0, groups.Length);

        // Spawn Group at current Position
        GameObject tetro_object = Instantiate(groups[i],
                    transform.position,
                    Quaternion.identity); //instantiate 生出來的是GameObject，用tetro_object這個位子來接它

       return tetro_object.GetComponent<Tetro>(); //從tetro_object身上找出"Tetro"的腳本，並回傳給呼叫這個function的人
    }
}
