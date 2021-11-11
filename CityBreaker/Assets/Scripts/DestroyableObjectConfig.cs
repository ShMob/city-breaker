using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DestroyableObjectConfig", menuName = "ObjectConfigs/DestroyableObjectConfig")]
public class DestroyableObjectConfig : ScriptableObject
{
    public string objectName;
    public int maxHit;
    public int score;
    public float dropProbability;
}
