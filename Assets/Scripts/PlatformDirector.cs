using UnityEngine;
using System.Collections;

public class PlatformDirector : BaseBehavior
{
    private GameObject _player;

    private float _lastHeight = 0;
    private float _distanceToGenerate = 5;
	
	public Transform Platform;
    public Transform BrokenPlatform;
    public Transform BouncyPlatform;
    public Transform DeadPlatform;

    public float PlatformRangeMin = 0.25F;
    public float PlatformRange = 0.35F;
    
    public float ChanceForBrokenPlatform = 0.1F;
    public float ChanceForBouncyPlatform = 0.15F;
    
    public float ChanceForDeadPlatform = 0.01F;

	public AudioSource JumpSound;

	public static PlatformDirector Current;

    void Start()
    {
        _player = GameObject.Find("Player");
		Current = this;
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

			Transform platform;
			
			if (Random.value < ChanceForBrokenPlatform)
			{
				platform = (Transform)Instantiate(BrokenPlatform, new Vector3(xPosition, _lastHeight, transform.position.z), Quaternion.identity);
			}
			else if (Random.value < ChanceForBouncyPlatform)
			{
				platform = (Transform)Instantiate(BouncyPlatform, new Vector3(xPosition, _lastHeight, transform.position.z), Quaternion.identity);
			}
			else
			{
	            platform = (Transform)Instantiate(Platform, new Vector3(xPosition, _lastHeight, transform.position.z), Quaternion.identity);
			}

			platform.parent = transform;
        }
    }
}
