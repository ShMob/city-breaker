using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodItemConfig", menuName = "FoodGameConfigs/FoodItemConfig")]
public class DestroyableObjectConfig : ScriptableObject
{
    public string objectName;
    //using mass wasn't working well for me, so i used rigidbody's drag instead
    public int maxHit;
    public int score;
}
