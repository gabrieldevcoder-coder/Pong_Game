using System;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle_Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //Promenne:
    public int smer_X = 0;
    public int smer_Y = 0;
	public bool isTopPaddle;
	void Start()
    {
		System.Random  Start_Direction = new System.Random();
        int direction = Start_Direction.Next(0, 2);//0= doprava 1= doleva
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (direction == 0)
        {
			rb.linearVelocity = new Vector2(5, 0);
            smer_X = 5;
		}
            
        else if (direction == 1)
		{
			rb.linearVelocity = new Vector2(-5, 0);
			smer_X = -5;
		}
	}

    // Update is called once per frame
    void Update()
    {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
        var touchscreen = Touchscreen.current;
        if(touchscreen != null)
        {
            foreach(var touch in touchscreen.touches)
            {
               if(touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)//klikl
                {
					float touchY = touch.position.ReadValue().y;//zjistime kdo klikl
					float paddleY = transform.position.y;//zjistime kde/ktera palka se ma pohnout

					bool isSameHalf =
						(touchY > Screen.height / 2 && paddleY > 0) ||
						(touchY <= Screen.height / 2 && paddleY < 0);

					if (isSameHalf)//pokud vse vychazi pokracujem
					{
						rb.linearVelocity *= -1;
					}
			    }
            }
            
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {

	}
}
