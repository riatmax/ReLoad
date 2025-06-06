using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField]
    protected int health;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private int scoreGiven;

    private GameManager gm;

    protected Load load;

    private void Awake()
    {
        load = FindFirstObjectByType<Load>();
        gm = FindFirstObjectByType<GameManager>();
    }
    protected void Update()
    {
        move();
        Die();
    }

    private void OnMouseDown()
    {
        health -= 1;
    }

    // follows player
    protected virtual void move()
    {
        if (load != null)
        {
            Vector2 direction = (load.gameObject.transform.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
        }
    }
    // check if it dies
    private void Die()
    {
        if (health <= 0)
        {
            gm.addScore(scoreGiven);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // checks if collision is our load and sets load's health and destroys
        if (collision.gameObject.GetComponent<Load>() != null)
        {
            collision.gameObject.GetComponent<Load>().setHealth(collision.gameObject.GetComponent<Load>().getHealth() - 1);
            Destroy(gameObject);
        }
    }

    public int getScore()
    {
        return this.scoreGiven;
    }
}
