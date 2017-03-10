using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour {

    public GameObject SinE = null;

    private SinEManager SinEM = null;
    private float tCount = 0;

	// Use this for initialization
	void Start () {
        SinEM = SinE.GetComponent<SinEManager>();
    }
	
	// Update is called once per frame
	void Update () {

        if (tCount > 0)
        {
            tCount += Time.deltaTime;
        }

		if (tCount > 2f)
        {
            tCount = 0;
            SceneManager.LoadScene(2);
        }
	}

    public void start()
    {
        tCount = 0.1f;
        SinE.SetActive(true);
        SinEM.type = 2;
    }

    public void menu()
    {
        SceneManager.LoadScene(1);
    }
}
