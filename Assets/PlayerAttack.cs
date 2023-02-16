using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement playerMovement;
    [SerializeField] private float attackCooldown;
    private float cooldownTimer;
    private GameObject attackArea = default;
    private bool attacking = false;

    public GameObject arrowPrefab;
    private void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            attack();
        if(attacking)
        {
            cooldownTimer += Time.deltaTime;
            if(cooldownTimer>= attackCooldown)
            {
                cooldownTimer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
        if (Input.GetMouseButtonDown(0))
        { 
            anim.SetTrigger("attackLeft");
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = direction * 5F;
            arrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            Destroy(arrow, 2f);
        }


    }
    private void attack()
    {
        attacking = true;
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        attackArea.SetActive(attacking);
    }
   
  
}
