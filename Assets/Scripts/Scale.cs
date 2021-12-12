using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    Vector3 start = Vector3.zero;
    Vector3 end = new Vector3(1f, 1.5f, 1f);
    float lerpTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(start, end, lerpTime);
        lerpTime += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Balloons"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 10000);
        }
    }
}
