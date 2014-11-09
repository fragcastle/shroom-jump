using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour
{
    public int JumpForce = 100;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered.");

        if (other.rigidbody2D.velocity.y <= 0)
            other.rigidbody2D.AddForce(new Vector2(0, JumpForce));
    }
}
