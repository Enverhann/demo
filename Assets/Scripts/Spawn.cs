using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }
}
