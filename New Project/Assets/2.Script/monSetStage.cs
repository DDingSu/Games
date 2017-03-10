using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monSetStage : MonoBehaviour {
    private float dt = 0;
    private float time = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dt += Time.deltaTime;

		if (gameObject.activeSelf == true && time + 0.3f < dt)
        {
            time += dt;
            gameObject.SetActive(false);
        }
	}
}
