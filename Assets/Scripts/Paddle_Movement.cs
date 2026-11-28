using System;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
public class Paddle_Movement : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created

	//Promenne:
	public int smer_X = 0;
	public int smer_Y = 0;
	public bool isTopPaddle;
	public float last_Speed = 5;
	public int direction = 0;
	void Start()
	{
		System.Random Start_Direction = new System.Random();
		direction = Start_Direction.Next(0, 2);//0= doprava 1= doleva
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		if (direction == 0)
		{
			rb.linearVelocity = new Vector2(last_Speed, 0);
			smer_X = 5;
		}

		else if (direction == 1)
		{
			rb.linearVelocity = new Vector2(-last_Speed, 0);
			smer_X = -5;
		}
	}

	// Update is called once per frame
	void Update()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		foreach (var touch in Touch.activeTouches)
		{
			if (touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
			{
				// Sem přijde tvoje současná logika
				float touchY = touch.screenPosition.y;//zjistime kdo klikl
				float paddleY = transform.position.y;//zjistime kde/ktera palka se ma pohnout

				bool isSameHalf =
					(touchY > Screen.height / 2 && paddleY > 0) ||
					(touchY <= Screen.height / 2 && paddleY < 0);

				if (isSameHalf)//pokud vse vychazi pokracujem
				{
					if (smer_X > 0)
					{
						rb.linearVelocity = new Vector2(-last_Speed, 0);
						smer_X *= -1;
					}
					else if (smer_X < 0)
					{
						rb.linearVelocity = new Vector2(last_Speed, 0);
						smer_X *= -1;
					}
				}
			}


		}
	}
	void OnEnable()
	{
		EnhancedTouchSupport.Enable();
	}

	void OnDisable()
	{
		EnhancedTouchSupport.Disable();
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Transform transform = GetComponent<Transform>();
		if(collision.gameObject.CompareTag("Ball") && transform.localScale.x >= 3)
		{
			transform.localScale -= new Vector3(0.5f, 0, 0);
		}
		else if(collision.gameObject.CompareTag("Ball") && transform.localScale.x >= 1)
		{
			transform.localScale -= new Vector3(0.25f, 0, 0);

		}
	}
}
