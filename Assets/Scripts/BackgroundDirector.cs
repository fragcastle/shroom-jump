using UnityEngine;
using System.Collections;

public class BackgroundDirector : BaseBehavior
{
    private GameObject _player;

    private float _lastHeight = 0;
    private float _distanceToGenerate = 5;

    public Transform Cloud;

	public float CloudRangeMin = 0.2F;
	public float CloudRange = 0.3F;

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
            var cloud = (Transform)Instantiate(Cloud, new Vector3(transform.position.x, _lastHeight, transform.position.z), Quaternion.identity);

			cloud.parent = transform;

            _lastHeight += CloudRangeMin;
        }

        while (_lastHeight < playerPosition.y + _distanceToGenerate)
        {
            _lastHeight += CloudRangeMin + (CloudRange * Random.value);

            var screenWidth = ScreenWidth();
            var xPosition = (screenWidth * Random.value) - (screenWidth / 2);

            var cloud = (Transform)Instantiate(Cloud, new Vector3(xPosition, _lastHeight, transform.position.z), Quaternion.identity);

            cloud.parent = transform;
        }
    }
}
