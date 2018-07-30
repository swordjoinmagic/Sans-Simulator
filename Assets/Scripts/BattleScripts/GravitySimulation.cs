using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于模拟重力的脚本
/// </summary>
public class GravitySimulation : MonoBehaviour {

    // 目标对象
    public Rigidbody2D target;
    public float a = 9.8f;     // 加速度
    public float maxVelocity = 5;       // 最大速度
    public float nowVelocity = 0;

	// Update is called once per frame
	void Update () {
        target.velocity = 
            Vector2.down * 
            Mathf.Clamp(nowVelocity + a * Time.deltaTime, 0, maxVelocity);
	}
}
