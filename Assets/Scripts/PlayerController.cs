using UnityEngine;
using System.Collections;

public class PlayerController : BaseBehavior
{
    private Animator _animator;
	private float _moveThreshold = 0F;
	
	private PlayerType _playerType;
	
	public float DistanceScale = 100;
	public int DistanceTraveled = 0;
	public int MoveForce = 10;
	
	public PlayerType PlayerType
	{
		get
		{
			return _playerType;
		}
		set
		{
			_playerType = value;
		}
	}

    void Start()
    {
        _animator = GetComponent<Animator>();

        if (PlayerPrefs.HasKey(Constants.PlayerTypeKey))
        {
            var playerType = PlayerPrefs.GetString(Constants.PlayerTypeKey);

            DestroyImmediate(_animator);

            _animator = gameObject.AddComponent<Animator>();

            var resource = Resources.Load("Animations/" + playerType + "Player/Player");
            var newAnimationController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(resource);
            _animator.runtimeAnimatorController = newAnimationController;
        }
    }

    void Update()
	{
		if (transform.position.y * DistanceScale > DistanceTraveled)
			DistanceTraveled = (int)(transform.position.y * DistanceScale);

        if (IsBelowTheFold(1))
        {
			AddHighScore(DistanceTraveled);

            Destroy(gameObject);
        }

        if (Mathf.Abs(rigidbody2D.velocity.y) < 1)
        {
            _animator.SetTrigger("Hovering");
        }
        else if (rigidbody2D.velocity.y < 0)
        {
            _animator.SetTrigger("Falling");
        }
        else
        {
            _animator.SetTrigger("Jumping");
        }

        var iPx = Input.acceleration.x;

        if (Input.GetKey(KeyCode.LeftArrow) || iPx < -_moveThreshold)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || iPx > _moveThreshold)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void FixedUpdate()
    {
        if (IsMobile())
        {
            var iPx = Input.acceleration.x;

            rigidbody2D.AddForce(new Vector2(MoveForce * Time.deltaTime * 20 * iPx, 0));
        }
        else
        {
            var xInput = Input.GetAxis("Horizontal");

            if (xInput != 0)
            {
                rigidbody2D.AddForce(new Vector2(xInput * MoveForce * Time.deltaTime * 10, 0));
            }
        }

        var screenWidth = ScreenWidth();
        var xRight = screenWidth / 2;
        var xLeft = -xRight;

        if (transform.position.x > xRight)
        {
            transform.position = new Vector3(xLeft, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < xLeft)
        {
            transform.position = new Vector3(xRight, transform.position.y, transform.position.z);
        }
    }

	private void AddHighScore(int score)
	{
		if (PlayerPrefs.HasKey(Constants.HighScoreKey))
		{
			var oldScore = PlayerPrefs.GetInt(Constants.HighScoreKey);
			
			PlayerPrefs.SetInt(Constants.PreviousHighScoreKey, oldScore);

			if (oldScore > score)
			{
				score = oldScore;
			}
		}
		
		PlayerPrefs.SetInt(Constants.HighScoreKey, score);
	}
}
