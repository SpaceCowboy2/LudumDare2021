using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tangage : MonoBehaviour
{
    public float maxAngle;
    public float angularSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.PingPong(Time.time, 2 * angularSpeed) - angularSpeed;
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, maxAngle * angle);
    }
}
