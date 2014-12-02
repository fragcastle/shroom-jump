using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSelection : MonoBehaviour
{
	private float _previousAxisInput = 0;

	private GameObject _player;
	private Animator _playerAnimator;
	
	public int _playerTypeIndex = 0;
	public List<PlayerType> _playerTypes = new List<PlayerType>();

	public PlayerType PlayerType
	{
		get
		{
			return _playerTypes[_playerTypeIndex];
		}
	}

	void Start()
	{
		DontDestroyOnLoad(this);
		
		_playerTypes.Add(PlayerType.Beige);
		_playerTypes.Add(PlayerType.Blue);
		_playerTypes.Add(PlayerType.Green);
		_playerTypes.Add(PlayerType.Yellow);
		_playerTypes.Add(PlayerType.Pink);

		_playerTypeIndex = 0;

		_player = GameObject.Find ("Player");
		_playerAnimator = _player.GetComponent<Animator>();
	}
	
	void Update()
	{
		var axisInput = Input.GetAxis("Horizontal");

		if (_previousAxisInput == 0)
		{
			if (axisInput > 0)
			{
				ChangePlayer(true);
			}
			else if (axisInput < 0)
			{
				ChangePlayer(false);
            }
        }

		_previousAxisInput = Input.GetAxis("Horizontal");
	}

	public void ChangePlayer(bool forward)
	{
		if (forward)
		{
			_playerTypeIndex++;
		}
		else
		{
			_playerTypeIndex--;
		}
		
		if (_playerTypeIndex >= _playerTypes.Count)
		{
			_playerTypeIndex = 0;
		}
		else if (_playerTypeIndex < 0)
		{
			_playerTypeIndex = _playerTypes.Count - 1;
		}
		
		var resource = Resources.Load("Animations/" + PlayerType + "Player/Player");
		var newAnimationController = (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(resource);
        _playerAnimator.runtimeAnimatorController = newAnimationController;
    }
    
    //	public Animator GetPlayerTypeAnimator()
//	{
//		if (PlayerType == PlayerType.Blue)
//		{
//			return 
//		}
//		else if (PlayerType == PlayerType.Beige)
//		{
//			PlayerType = PlayerType.Blue;
//		}
//	}
}
