using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetroSpawn : MonoBehaviour //attached on Spawner
{
    // Groups
    public GameObject[] groups;

    public Tetro spawnNext()
    {
        //Debug.Log("spawn");
        // Random Index
        int i = Random.Range(0, groups.Length);

        // Spawn Group at current Position
        return Instantiate(groups[i],
                    transform.position,
                    Quaternion.identity).GetComponent<Tetro>();
    }
}
