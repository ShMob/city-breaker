using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveAmount;
    public float bouncingAngleTolerance;
    public float magnitudeLimit;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1 * moveAmount * Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private float Magnitude(float x, float z)
    {
        return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(z, 2));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "DeathZone")
        {
            Debug.Log("DEAD");
        }
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
            float magnitude = Magnitude(forceVector.x, forceVector.z);
            if(magnitude > magnitudeLimit)
            {
                forceVector.z -= Math.Sign(forceVector.z) * magnitude / 2;
                forceVector.x -= Math.Sign(forceVector.x) * magnitude / 2;
            }
            Debug.Log(forceVector);
            GetComponent<Rigidbody>().AddForce(forceVector);
        }
    }
}
