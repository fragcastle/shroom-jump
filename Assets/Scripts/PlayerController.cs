using UnityEngine;
using System.Collections;

public class PlayerController : BaseBehavior
{
    private Animator _animator;
    private float _moveThreshold = 0F;

    public int MoveForce = 10;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsBelowTheFold(1))
        {
            Destroy(gameObject);
        }

        if (Mathf.Abs(rigidbody2D.velocity.y) < 1)
        {
            _animator.SetTrigger("Hovering");
        }
        else if (rigidbody2D.velocity.y < 0)
        {
            _animator.SetTrigger("Falling");
        }
        else
        {
            _animator.SetTrigger("Jumping");
        }

        var iPx = Input.acceleration.x;

        if (Input.GetKey(KeyCode.LeftArrow) || iPx < -_moveThreshold)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || iPx > _moveThreshold)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void FixedUpdate()
    {
        var iPx = Input.acceleration.x;

        if (Input.GetKey(KeyCode.LeftArrow) || iPx < -_moveThreshold)
        {
            if (IsMobile())
            {
                rigidbody2D.AddForce(new Vector2(MoveForce * Time.deltaTime * 20 * iPx, 0));
            }
            else
            {
                rigidbody2D.AddForce(new Vector2(-MoveForce * Time.deltaTime * 10, 0));
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || iPx > _moveThreshold)
        {
            if (IsMobile())
            {
                rigidbody2D.AddForce(new Vector2(MoveForce * Time.deltaTime * 20 * iPx, 0));
            }
            else
            {
                rigidbody2D.AddForce(new Vector2(MoveForce * Time.deltaTime * 10, 0));
            }
        }

        var screenWidth = ScreenWidth();
        var xRight = screenWidth / 2;
        var xLeft = -xRight;

        if (transform.position.x > xRight)
        {
            transform.position = new Vector3(xLeft, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < xLeft)
        {
            transform.position = new Vector3(xRight, transform.position.y, transform.position.z);
        }
    }
}
