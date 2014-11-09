using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        var playerPosition = _player.transform.position;

        if (playerPosition.y >= transform.position.y)
            transform.position = new Vector3(transform.position.x, playerPosition.y, transform.position.z);
    }
}
