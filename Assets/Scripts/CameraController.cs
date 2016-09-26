using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject Player;
	private Vector3 offset;


	// Use this for initialization


	void Start () 
	{
		offset = transform.position - Player.transform.position;
	}



	//Runs after all things have been done and processed in update
	void LateUpdate () 
	{
		transform.position = Player.transform.position + offset;
	}
}
