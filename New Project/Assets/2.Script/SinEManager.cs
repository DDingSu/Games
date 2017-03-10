using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinEManager : MonoBehaviour {
    public Image im = null;
    public int type = 0;

	// Use this for initialization
	void Start () {
        type = 1;
        im.color = new Color(0, 0, 0, 1);

    }
	
	// Update is called once per frame
	void Update () {
        if (type == 1)
        {
            if (im.color.a > 0)
            {
                im.color -= new Color(0, 0, 0, 1) * Time.deltaTime;
            }
        }
        if (type == 2)
        {
            if (im.color.a > 0)
            {
                im.color += new Color(0, 0, 0, 1) * Time.deltaTime;
            }
        }
        if (im.color.a <= 0)
        {
            type = 0;
            im.color = new Color(0, 0, 0, 0.01f);
            gameObject.SetActive(false);
        }
    }
}
