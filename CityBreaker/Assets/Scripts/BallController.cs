using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveAmount;
    public float bouncingAngleTolerance;
    public float magnitudeLimit;
    public float speed;
    private Rigidbody rb;
    private Vector3 force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, -1 * moveAmount * Time.deltaTime));
        GetComponent<MeshRenderer>().material.color = new Color(0.7292346f, 0.6367924f, 1, 1);
        force = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(force != Vector3.zero)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(force);
            force = Vector3.zero;
        }
    }

    private float Magnitude(float x, float z)
    {
        return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(z, 2));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeathZone")
        {
            Debug.Log("DEAD");
            FindObjectOfType<SceneController>().LoseBall();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            Vector3 forceVector = collision.contacts[0].normal * moveAmount;
            forceVector.y = 0;
            if (Math.Abs(forceVector.z) < bouncingAngleTolerance)
            {
                if (forceVector.z == 0)
                    forceVector.z = -200;
                else
                    forceVector.z = Math.Sign(forceVector.z) * 200;
            }
            Debug.Log(forceVector);
            float magnitude = Magnitude(forceVector.x, forceVector.z);
            forceVector.x = forceVector.x / magnitude * speed;
            forceVector.z = forceVector.z / magnitude * speed;
            Debug.Log(forceVector);
            force = forceVector;
        }
    }
}
