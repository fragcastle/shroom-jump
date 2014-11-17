using UnityEngine;
using System.Collections;

public class PressSpaceToStart : MonoBehaviour
{
	void Start ()
	{
	
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			Application.LoadLevel("level-01");
		}
	}
}
