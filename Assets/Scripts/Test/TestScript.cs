using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class TestScript : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	Vector3 position = new Vector3();
	float speed = 3f;
	Rigidbody2D rb;
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		rb.linearVelocity = new Vector2(5, 0);//!vector 2!
	}

	// Update is called once per frame
	void Update()
    {

	}
	void FixedUpdate()
	{
	}
}
