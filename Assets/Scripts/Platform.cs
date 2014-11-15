using UnityEngine;
using System.Collections;

public class Platform : BaseBehavior
{
    private Transform _player;

    public bool IsBroken = false;
    public float JumpSpeed = 3.5F;

    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (!_player)
            return;

        if (!collider2D.enabled && _player.position.y > transform.position.y && _player.rigidbody2D.velocity.y <= 0)
        {
            collider2D.enabled = true;
        }
        else if (collider2D.enabled && _player.position.y < transform.position.y)
        {
            collider2D.enabled = false;
        }

        if (IsBelowTheFold())
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.rigidbody.velocity.y <= 0)
        {
            collision2D.rigidbody.velocity = new Vector2(collision2D.rigidbody.velocity.x, JumpSpeed);

            collider2D.enabled = false;

            if (IsBroken)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision2D)
    {
        if (collision2D.rigidbody.velocity.y <= 0)
        {
            collision2D.rigidbody.velocity = new Vector2(collision2D.rigidbody.velocity.x, JumpSpeed);

            collider2D.enabled = false;

            if (IsBroken)
            {
                Destroy(gameObject);
            }
        }
    }
}
