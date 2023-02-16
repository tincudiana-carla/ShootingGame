using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject treant;
    [SerializeField]
    private GameObject mole;
    [SerializeField]
    private float treantInterval = 5F;
    [SerializeField]
    private float moleInterval = 15F;
    private void Start()
    {
        StartCoroutine(spawnEnemy(treantInterval, treant));
        StartCoroutine(spawnEnemy(moleInterval, mole));
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-1f,1f),Random.Range(-1f, 1f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
