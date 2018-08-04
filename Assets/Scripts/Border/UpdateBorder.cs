using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBorder : MonoBehaviour {

    public RectTransform rect;

	// Use this for initialization
	void Start () {
        print("rect:"+rect.position);
        print("rect的世界坐标是:"+Camera.main.ScreenToWorldPoint(rect.position));
	}
}
