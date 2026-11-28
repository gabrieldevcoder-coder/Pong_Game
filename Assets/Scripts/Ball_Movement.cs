using Unity.VisualScripting;
using UnityEngine;

public class Ball_Movement : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	public Game_Manager game_Manager;
	public float Speed = 1.1f;
	public int bounce_Counter = 0;
    void Direction()
    {
		bounce_Counter = 0;
		Speed = 1.1f;
		Transform transform = GetComponent<Transform>();
		transform.position = new Vector2(0,0);
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		int direction = UnityEngine.Random.Range(1, 17);
		switch (direction)
		{
			case 1:
				rb.linearVelocity = new Vector2(5, 2);
				break;
			case 2:
				rb.linearVelocity = new Vector2(5, 3);
				break;
			case 3:
				rb.linearVelocity = new Vector2(5, 4);
				break;
			case 4:
				rb.linearVelocity = new Vector2(4, 5);
				break;

			case 5:
				rb.linearVelocity = new Vector2(-5, 2);
				break;
			case 6:
				rb.linearVelocity = new Vector2(-5, 3);
				break;
			case 7:
				rb.linearVelocity = new Vector2(-5, 4);
				break;
			case 8:
				rb.linearVelocity = new Vector2(-4, 5);
				break;

			case 9:
				rb.linearVelocity = new Vector2(-5, -2);
				break;
			case 10:
				rb.linearVelocity = new Vector2(-5, -3);
				break;
			case 11:
				rb.linearVelocity = new Vector2(-5, -4);
				break;
			case 12:
				rb.linearVelocity = new Vector2(-4, -5);
				break;

			case 13:
				rb.linearVelocity = new Vector2(5, -2);
				break;
			case 14:
				rb.linearVelocity = new Vector2(5, -3);
				break;
			case 15:
				rb.linearVelocity = new Vector2(5, -4);
				break;
			case 16:
				rb.linearVelocity = new Vector2(4, -5);
				break;
		}
	}
	void Start()
    {
        Direction();
    }

    // Update is called once per frame
    void Update()
    {
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Score_Zone_Up"))//pridat bod druhemu tymu a dat zpatky na zacatek
		{
			//dat bod hraci dole
			//Debug.Log("1fgf");

			game_Manager.AddScore(0);//player 1 scored tzn. player 1 is the downside

			Direction();
		}
		if(collision.gameObject.CompareTag("Score_Zone_Down"))//pridat bod druhemu tymu a dat zpatky na zacatek
		{
			//dat bod hraci nahore
			//Debug.Log("2fgf");
			game_Manager.AddScore(1);//player 2 scored


			Direction();
		}

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		if (bounce_Counter < 10)
		{
			rb.linearVelocity *= Speed;
		}
		else if(bounce_Counter < 15)
		{
			Speed = 1.05f;
			rb.linearVelocity *= Speed;
		}
		bounce_Counter++;

		
	}
}
