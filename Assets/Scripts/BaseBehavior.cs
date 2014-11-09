using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class BaseBehavior : MonoBehaviour
{
    public bool IsBelowTheFold()
    {
        var halfHeight = Screen.height / 2;

        var p1 = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var p2 = Camera.main.ScreenToWorldPoint(new Vector3(0, halfHeight, 0));
        var distance = Vector3.Distance(p1, p2);

        return (Camera.main.transform.position.y - distance > transform.position.y);
    }
}
