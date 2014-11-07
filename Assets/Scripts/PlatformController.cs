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

    void OnCollisionEnter2D(Collision2D collision2d)
    {
        collision2d.rigidbody.AddForce(new Vector2(0, JumpForce));
    }
}
