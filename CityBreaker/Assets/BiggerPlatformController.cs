using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerPlatformController : PowerUpController
{
    //This power up increases the length of the platform
    public override void OnConsume()
    {
        FindObjectOfType<PlatformController>().UseBiggerPlatformPowerup();
    }
}
