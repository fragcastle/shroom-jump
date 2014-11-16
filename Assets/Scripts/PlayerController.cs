using UnityEngine;
using System.Collections;

public class PlayerController : BaseBehavior
{
    private Animator _animator;

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
		
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.AddForce(new Vector2(-MoveForce * Time.deltaTime * 10, 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.AddForce(new Vector2(MoveForce * Time.deltaTime * 10, 0));
        }
    }
}
