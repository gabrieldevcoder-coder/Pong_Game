using UnityEngine;
using UnityEngine.InputSystem;

public class TouchExperiment : MonoBehaviour
{
    //promenne:
    int? player1_ID = null;
    int? player2_ID = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    Vector2 position = Mouse.current.position.ReadValue();
        //    Debug.Log(position);
        //    if (position.y < Screen.height / 2)
        //    {
        //        Debug.Log("dolni polovina");
        //    }
        //    else if (position.y > Screen.height / 2)
        //        Debug.Log("horni polovina");
        //}
        var touchscreen = Touchscreen.current;
        if(touchscreen != null)
            foreach(var touch in touchscreen.touches)
            {
                if(touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
                {
                    if(touch.position.ReadValue().y > Screen.height/2 && player1_ID == null)
                    {
                        player1_ID = touch.touchId.ReadValue();
                        Debug.Log(player1_ID);
                        Debug.Log("player1 tapped");
						//horni polovina

					}
                    else if(touch.position.ReadValue().y <= Screen.height / 2 && player2_ID == null)
					{
						//dolni polovina + stred
						player2_ID = touch.touchId.ReadValue();
						Debug.Log(player2_ID);
                        Debug.Log("player2 tapped");
						//horni polovina
						
					}
                   
				}
                else if(touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Ended || touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Canceled)
                {
					if (player1_ID == touch.touchId.ReadValue())
					{
                        player1_ID = null;
                        //horni polovina

					}
					else if (player2_ID == touch.touchId.ReadValue())
					{
                        //dolni polovina + stred
                        player2_ID = null;
						//horni polovina

					}
				}
                    

			}
        

    }   
}
