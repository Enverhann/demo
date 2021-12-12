//couldn't make pile of balloons clamped together
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public List<GameObject> targets;
    private GameObject player;
    public float Timer = 2;
    // Start is called before the first frame update 
    void Start()
    {
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            StartCoroutine(SpawnTarget());
            Timer = 2f;
        }
    }

    IEnumerator SpawnTarget()
    {     
        yield return new WaitForSeconds(Random.Range(1, 1.5f));
        int index = Random.Range(0, targets.Count);
        GameObject newBalloons= Instantiate(targets[index], new Vector3 (Random.Range(transform.position.x-0.1f,transform.position.x+0.1f),(transform.position.y+0.8f),transform.position.z), Quaternion.identity, transform) as GameObject;
        newBalloons.transform.parent = transform;   
    }
}
