using UnityEngine;
using System.Collections;

public class DecorationDirector : BaseBehavior
{
    private GameObject _player;

    private float _lastHeight = 0;
    private float _distanceToGenerate = 5;

    public Transform Decoration;

    public float DecorationRangeMin = 0.2F;
	public float DecorationRange = 0.3F;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        if (!_player)
            return;

        var playerPosition = _player.transform.position;

		// Generate the first decoration in the center of screen
        if (_lastHeight == 0)
        {
            var decoration = (Transform)Instantiate(Decoration, new Vector3(transform.position.x, _lastHeight, transform.position.z), Quaternion.identity);

			decoration.parent = transform;

			_lastHeight += DecorationRangeMin;
        }

        while (_lastHeight < playerPosition.y + _distanceToGenerate)
        {
			_lastHeight += DecorationRangeMin + (DecorationRange * Random.value);

            var screenWidth = ScreenWidth();
            var xPosition = (screenWidth * Random.value) - (screenWidth / 2);

			var decoration = (Transform)Instantiate(Decoration, new Vector3(xPosition, _lastHeight, transform.position.z), Quaternion.identity);

			decoration.parent = transform;
        }
    }
}
