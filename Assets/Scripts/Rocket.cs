﻿using System.Linq;
using UnityEngine;

public class Rocket : MonoBehaviour, IDamageable
{
    public Player player;
    public float speed;
    public Explosion explotion;
    private RaycastHit2D[] rayHits = new RaycastHit2D[16];
    private Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(col, player.col);
    }

    void FixedUpdate()
    {
        int hits = col.Cast(transform.up, rayHits, speed*Time.fixedDeltaTime);

        for (int i = 0; i < hits; i++)
        {
            if (((1 << rayHits[i].collider.gameObject.layer) & player.weaponIgnore) != 0)
                continue;

            if (player != null && rayHits[i].collider.GetComponent<Player>() == player)
                continue;

            transform.position += transform.up*rayHits[i].distance;
            Explode();
            return;
        }

        transform.position += transform.up*speed*Time.fixedDeltaTime;
    }

    public void Damage(float damage)
    {
        Explode();
    }

    private void Explode()
    {
        Instantiate(explotion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
