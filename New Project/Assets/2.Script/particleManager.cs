using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleManager : MonoBehaviour {
    public int type = 0;
    public GameObject Player = null;

    private float dt = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dt += Time.deltaTime;

        switch (type)
        {
            case 1:
                transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -1);
                break;
            case 2:
                if (dt >= 2f)
                    Destroy(gameObject);
                break;
        }
	}
}
