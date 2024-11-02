using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D projectileRb;
    [SerializeField] private float speed;
    [SerializeField] private float projectileLife;
    [SerializeField] private float projectileCount;
    private PlayerMovementTD playerMovement;
    private bool facingRight;

    void Start()
    {
        projectileCount = projectileLife;
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementTD>();
        facingRight = playerMovement.facingRight;
        if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        facingRight = true;
    }


    void Update()
    {
        projectileCount -= Time.deltaTime;
        if (projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void FixedUpdate()
    {
        if (facingRight)
        {
            projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
        }
        else
        {
            projectileRb.velocity = new Vector2(-speed, projectileRb.velocity.y);
        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}



