using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    private bool dead;
    [SerializeField] private float startingHealth;
    public float currentHealth;

    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOffFlashes;
    private SpriteRenderer spriteRend;
    public GameObject enemy;
    public GameObject gold;
    private void Awake()
    {
        currentHealth = startingHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            //hurt
            StartCoroutine(Invulnerability());
        }
        else if (currentHealth == 0)
        {
            //death
            if (!dead)
            {
                GetComponent<Enemy>().enabled = false;
                enemy.SetActive(false);
                dead = true;
                gold = Instantiate(gold, transform.position, Quaternion.identity);
                Destroy(enemy);
            }
        }
    }
    public void setHealth(float maxHealth, float health)
    {
        startingHealth = maxHealth;
        health = currentHealth;
    }
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(8, 7, true);
        for (int i = 0; i < numberOffFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5F);
            yield return new WaitForSeconds(iFramesDuration / (numberOffFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOffFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 7, false);
    }

}
