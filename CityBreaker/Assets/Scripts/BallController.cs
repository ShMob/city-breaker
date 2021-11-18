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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, -1 * moveAmount * Time.deltaTime));
        GetComponent<MeshRenderer>().material.color = new Color(0.5f, 1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

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
                Debug.Log("in if");
                if (forceVector.z == 0)
                    forceVector.z = -200;
                else
                    forceVector.z = Math.Sign(forceVector.z) * 200;
            }
            Debug.Log(forceVector);
            float magnitude = Magnitude(forceVector.x, forceVector.z);
            //if(magnitude > magnitudeLimit)
            //{
            //    forceVector.z -= Math.Sign(forceVector.z) * magnitude / 2;
            //    forceVector.x -= Math.Sign(forceVector.x) * magnitude / 2;
            //}
            //float forceSum = forceVector.x + forceVector.z;
            forceVector.x = forceVector.x / magnitude * speed;
            forceVector.z = forceVector.z / magnitude * speed;
            Debug.Log(forceVector);
            rb.velocity = Vector3.zero;
            rb.AddForce(forceVector);
        }
    }
}
