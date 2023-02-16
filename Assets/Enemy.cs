using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    private float damage = 5;
    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private enemyData data;
    private GameObject player;
    
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Animator anim;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Treant();
        setEnemyValues();
    }
    private void Treant()
    {
       
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        
        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        if (angle > 45 && angle <= 135)
        {
            spriteRenderer.sprite = upSprite;
            anim.SetTrigger("up");
            
        }
        else if (angle > 135 || angle <= -135)
        {
            spriteRenderer.sprite = leftSprite;
            Vector3 scale = spriteRenderer.transform.localScale;
            scale.x = -2 ;
            spriteRenderer.transform.localScale = scale;
            anim.SetTrigger("left");


        }
        else if (angle > -135 && angle <= -45)
        {
            spriteRenderer.sprite = downSprite;
            anim.SetTrigger("down");

        }
        else
        {
            spriteRenderer.sprite = rightSprite;
            Vector3 scale = spriteRenderer.transform.localScale;
            scale.x = 2;
            spriteRenderer.transform.localScale = scale;
            anim.SetTrigger("right");

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(collision.GetComponent<PlayerHealth>() != null)
            {
                collision.GetComponent<PlayerHealth>().TakeDamage(damage);
                this.GetComponent<PlayerHealth>().TakeDamage(10);
            }
        }

    }
    private void setEnemyValues()
    {
        GetComponent<EnemyHealth>().setHealth(data.HP, data.HP);
        damage = data.damage;
        speed = data.speed;
    }   
    
}
