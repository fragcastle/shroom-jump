using UnityEngine;
using System.Collections;

public class PlatformController : BaseBehavior
{
    private bool _activated = false;
    private Transform _player;
    public float JumpSpeed = 3.5F;

    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (!_activated && _player.position.y > transform.position.y)
        {
            var collider = GetComponent<BoxCollider2D>();
            collider.enabled = true;
        }
        else if (_activated && _player.position.y < transform.position.y)
        {
            var collider = GetComponent<BoxCollider2D>();
            collider.enabled = false;
        }

        if (IsBelowTheFold())
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.rigidbody.velocity.y <= 0)
            collision2D.rigidbody.velocity = new Vector2(collision2D.rigidbody.velocity.x, JumpSpeed);
    }
}
