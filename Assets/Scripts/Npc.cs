using UnityEngine;
using System.Collections;

public class Npc : MonoBehaviour
{
    private int _direction = -1;
    private float _speed = 0.1F;
    
    void Start()
    {
        if (Random.value < 0.5)
        {
            _direction = 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    
    void Update()
    {
        transform.position = new Vector2(transform.position.x + Time.deltaTime * _speed * _direction, transform.position.y);
    }
}
