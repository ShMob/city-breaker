using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePowerUpController : PowerUpController
{
    //This power up generates a new ball
    public override void OnConsume()
    {
        FindObjectOfType<SceneController>().NewBall();   
    }
}
