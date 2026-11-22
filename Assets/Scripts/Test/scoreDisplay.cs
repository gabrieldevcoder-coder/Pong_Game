using UnityEngine;

public class cores : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	public scoreManager manager;


    void Start()
    {
		Debug.Log(manager.score);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
