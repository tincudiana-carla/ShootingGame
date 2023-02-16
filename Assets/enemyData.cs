using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 1)]
public class enemyData : ScriptableObject
{
    public float HP;
    public float damage;
    public float speed;
}
