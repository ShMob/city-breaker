using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private float moveAmount=5f;
    public virtual void OnConsume() { }

    private void Start()
    {
    }

    void FixedUpdate()
    {
        Vector3 position = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(position.x, position.y, position.z - (Time.deltaTime * moveAmount));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            OnConsume();
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("DeathZone"))
        {
            Destroy(this.gameObject);
        }
    }

}
