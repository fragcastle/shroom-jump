using UnityEngine;
using System.Collections;

public class PlatformDirector : BaseBehavior
{
    private GameObject _player;

    private float _lastHeight = 0;
    private float _distanceToGenerate = 2;

    public Transform Platform;

    public float PlatformRangeMin = 0.2F;
    public float PlatformRange = 0.3F;

    public float ChanceForBrokenPlatform = 0.1F;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        if (!_player)
            return;

        var playerPosition = _player.transform.position;

        // Generate the first platform in the center of screen
        if (_lastHeight == 0)
        {
            var platform = (Transform)Instantiate(Platform, new Vector3(transform.position.x, _lastHeight, transform.position.z), Quaternion.identity);

            platform.parent = transform;

            _lastHeight += PlatformRangeMin;
        }

        while (_lastHeight < playerPosition.y + _distanceToGenerate)
        {
            _lastHeight += PlatformRangeMin + (PlatformRange * Random.value);

            var screenWidth = ScreenWidth();
            var xPosition = (screenWidth * Random.value) - (screenWidth / 2);

            var platform = (Transform)Instantiate(Platform, new Vector3(xPosition, _lastHeight, transform.position.z), Quaternion.identity);

            platform.parent = transform;

            if (Random.value < ChanceForBrokenPlatform)
            {
                platform.gameObject.GetComponent<Platform>().IsBroken = true;
            }
        }
    }
}
