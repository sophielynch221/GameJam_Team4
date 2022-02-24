using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    public GameObject projectile;

    public void Ini(Vector2 dir)
    {
        rb.velocity = dir * speed;
        Destroy(gameObject);
    }
    
    
}
