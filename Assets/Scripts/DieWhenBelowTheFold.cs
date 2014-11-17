using UnityEngine;
using System.Collections;

public class DieWhenBelowTheFold : BaseBehavior
{
	void Start ()
	{
	
	}
	
	void Update ()
	{
		if (IsBelowTheFold())
		{
			Destroy(gameObject);
		}
	}
}
