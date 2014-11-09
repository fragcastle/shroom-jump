using UnityEngine;
using System.Collections;

public class PlatformDirector : MonoBehaviour
{
    private GameObject _player;

    private float _lastHeight = 0;
    private float _distanceToGenerate = 2;

    public Transform Platform;

    public float PlatformRange = 0.5F;
    public float PlatformStartingFrequency = 0.5F;
    public float PlatformFrequencyDrop = 0.5F;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        var playerPosition = _player.transform.position;

        while (_lastHeight < playerPosition.y + _distanceToGenerate)
        {
            _lastHeight += 0.2F;

            Instantiate(Platform, new Vector3(transform.position.x, _lastHeight, transform.position.z), Quaternion.identity);
        }
    }
}
