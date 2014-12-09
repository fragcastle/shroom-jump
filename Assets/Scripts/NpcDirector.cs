using UnityEngine;
using System.Collections;

public class NpcDirector : BaseBehavior
{
    private GameObject _player;

    private float _lastHeight = 0;
    private float _distanceToGenerate = 5;

    public Transform[] Npcs;

    public float DecorationRangeMin = 0.2F;
	public float DecorationRange = 0.3F;

    void Start()
    {
        _player = GameObject.Find("Player");
        
        _lastHeight += DecorationRangeMin + (DecorationRange * Random.value);
    }

    void Update()
    {
        if (!_player)
            return;

        var playerPosition = _player.transform.position;

        while (_lastHeight < playerPosition.y + _distanceToGenerate)
        {
			_lastHeight += DecorationRangeMin + (DecorationRange * Random.value);

            var screenWidth = ScreenWidth();
            var xPosition = (screenWidth * Random.value) - (screenWidth / 2);

            var decoration = (Transform)Instantiate(Npcs[RandomIndex(Npcs.Length)], new Vector3(xPosition, _lastHeight, transform.position.z), Quaternion.identity);

			decoration.parent = transform;
        }
    }
}
