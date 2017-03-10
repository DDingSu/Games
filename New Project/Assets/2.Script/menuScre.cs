using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuScre : MonoBehaviour {
    public GameObject obj = null;
    public int stage = 0;
    public int killMon = 0;
    public Text tx = null;

    // Use this for initialization
    void Start () {
        obj = GameObject.Find("Obj");
        if (obj != null)
        {
            GameManager gM = obj.GetComponent<GameManager>();
            stage = gM.stage;
            killMon = gM.killMon;
            Destroy(obj);

            tx.text = stage + "";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
