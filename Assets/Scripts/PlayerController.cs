using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int MoveForce = 10;

    void Start()
    {

    }

    void Update()
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
