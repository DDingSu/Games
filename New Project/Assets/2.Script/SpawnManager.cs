using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public bool onOff = false;

    // 몬스터    5
    public GameObject[] mon = null;

    // 몬스터 나올 확률    5
    public float[] monRan = null;
    private float monRnum = 0;
    private float num = 0;
    private GameObject monInstan = null;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawnMon();
	}

    void spawnMon()
    {
        if (onOff)
        {
            monRnum = Random.Range(0, 100);
            if (num + monRan[0] > monRnum)
            {
                monInstan = Instantiate(mon[0]);
                monInstan.transform.position = transform.position;
            }
            else
            {
                num += monRan[0];
                if (num + monRan[1] > monRnum)
                {
                    monInstan = Instantiate(mon[1]);
                    monInstan.transform.position = transform.position;
                }
                else
                {
                    num += monRan[1];
                    if (num + monRan[2] > monRnum)
                    {
                        monInstan = Instantiate(mon[2]);
                        monInstan.transform.position = transform.position;
                    }
                    else
                    {
                        num += monRan[2];
                        if (num + monRan[3] > monRnum)
                        {
                            monInstan = Instantiate(mon[3]);
                            monInstan.transform.position = transform.position;
                        }
                        else
                        {
                            num += monRan[3];
                            if (num + monRan[4] > monRnum)
                            {
                                monInstan = Instantiate(mon[4]);
                                monInstan.transform.position = transform.position;
                            }
                        }
                    }
                }
            }
            num = 0;
            onOff = false;
        }
    }
}
