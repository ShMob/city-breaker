using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyableObjectController : MonoBehaviour
{
    private int maxHit;
    private int score;
    public DestroyableObjectConfig config;
    private int hit;
    //public DestroyableObjectConfig config;
    private void Awake()
    {
        maxHit = config.maxHit;
        score = config.score;
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        if (maxHit > 1)
        {
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        if(gameObject.name == "greek_roof_1_square")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        hit = 0;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Debug.Log(gameObject.name + "got hit!");
            hit++;
            if(hit == maxHit - 1)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
            }
            if(hit == maxHit)
            {
                DropPowerUp();
                FindObjectOfType<SceneController>().IncreaseScore(config.score);
                StartCoroutine("DestroyYourself");
                FindObjectOfType<SceneController>().updateObjectNumbers(-1);
            }
        }
    }

    private void DropPowerUp()
    {
        if(UnityEngine.Random.Range(0f, 1f) <= config.dropProbability)
        {
            GameObject powerUp = FindObjectOfType<SceneController>().GetPowerUp();
            powerUp.transform.position = new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z);
            Instantiate(powerUp);
        }
    }

    public IEnumerator DestroyYourself()
    {
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("Destroying" + gameObject.name);
        if(this.gameObject.name == "GameObject")
        {
            Destroy(this.transform.parent.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}
