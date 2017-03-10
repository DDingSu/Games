using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	private bool moveC = false;
	private Vector3 vect = Vector3.zero;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (moveC == true)
		{
			transform.position = Vector3.Lerp(transform.position, vect, 0.1f);

			moveC = false;
		}
	}

	void moveCamera(Vector3 player)
	{
		vect = new Vector3(player.x, player.y, -10);

		moveC = true;
	}
}