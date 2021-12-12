using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 targetAngle = new Vector3(0f, 0, 20f);

    private Vector3 currentAngle;

    public void Start()
    {
        currentAngle = transform.eulerAngles;
    }

    public void Update()
    {
        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime));

        transform.eulerAngles = currentAngle;
    }
}
