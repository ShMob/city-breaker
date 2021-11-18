using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float moveAmount;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseBiggerPlatformPowerup()
    {
        StartCoroutine("IncreaseLength");
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if(transform.position.x < 12)
                transform.position += new Vector3(moveAmount * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -12)
                transform.position += new Vector3(-moveAmount * Time.deltaTime, 0, 0);
        }
    }

    public IEnumerator IncreaseLength()
    {
        gameObject.transform.localScale += new Vector3(2, 0, 0);
        yield return new WaitForSecondsRealtime(10);
        gameObject.transform.localScale += new Vector3(-2, 0, 0);
    }
}
