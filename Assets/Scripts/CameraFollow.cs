using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float y;
    private Vector3 offset;
    public float speedFollow = 5f;
    // Start is called before the first frame update

    void Start()
    {
        offset = transform.position;
    }

    void LateUpdate()
    {
        Vector3 followPos = target.position + offset;
        RaycastHit hit;
        if (Physics.Raycast(target.position, Vector3.down, out hit, 2.5f))
            y = Mathf.Lerp(y, hit.point.y, Time.deltaTime * speedFollow);
        else y = Mathf.Lerp(y, target.position.y, Time.deltaTime * speedFollow);
        followPos.y = offset.y + y;
        transform.position = followPos;
    }
}
