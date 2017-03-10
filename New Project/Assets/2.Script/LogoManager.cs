using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoManager : MonoBehaviour {

    public GameObject SinE = null;

    private SinEManager SinEM = null;
    private float tCount = 0;
    private float dt = 0;
    private bool qwe = true;

    // Use this for initialization
    void Start () {
        SinEM = SinE.GetComponent<SinEManager>();
    }
	
	// Update is called once per frame
	void Update () {
        dt += Time.deltaTime;

        Debug.Log(tCount);

        if (tCount > 0)
        {
            tCount += Time.deltaTime;
        }

        if (tCount > 2f)
        {
            tCount = 0;
            SceneManager.LoadScene(1);
        }

        if (dt > 1.5f && qwe == true)
        {
            qwe = false;
            tCount = 0.1f;
            SinE.SetActive(true);
            SinEM.type = 2;
        }
    }
}
