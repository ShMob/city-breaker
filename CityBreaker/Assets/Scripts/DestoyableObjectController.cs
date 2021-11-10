using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyableObjectController : MonoBehaviour
{
    public int maxHit;
    public int score;
    //public DestroyableObjectConfig config;
    private void Awake()
    {
        //if(maxHit > 1)
        //{
        //    Rigidbody rb = GetComponent<Rigidbody>();
        //    rb.constraints = RigidbodyConstraints.FreezeAll;
        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
        }
    }
}
