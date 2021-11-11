using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyableObjectController : MonoBehaviour
{
    private int maxHit;
    private int score;
    private float dropProbability;
    public DestroyableObjectConfig config;
    private int hit;
    //public DestroyableObjectConfig config;
    private void Awake()
    {
        maxHit = config.maxHit;
        score = config.score;
        dropProbability = config.dropProbability;
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        if (maxHit > 1)
        {
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        hit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            hit++;
            if(hit == maxHit - 1)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
            }
            if(hit == maxHit)
            {
                StartCoroutine("DestroyYourself");
            }
        }
    }

    public IEnumerator DestroyYourself()
    {
        yield return new WaitForSecondsRealtime(1f);
        Destroy(this.gameObject);
    }
}
