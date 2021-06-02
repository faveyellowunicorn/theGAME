using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    float v;
    float h;
    Rigidbody rb;
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }
    void Update()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        rb.velocity = tr.forward * v * 100f;
        rb.AddForce(tr.right * h * 1500f);



    }

    public void Poluchatel(float arg)
    {
        transform.rotation = Quaternion.Euler(0, arg, 0);
    }
}
