using UnityEngine;
using System.Collections;

public class MonsterManager : MonoBehaviour {
	public GameObject player = null;
	public GameObject qwe = null;
	public GameObject newBarrier = null;
	public GameObject Barrier = null;
	public GameObject Obj = null;
    public ParticleSystem newPart = null;
    public ParticleSystem diyPart = null;
    public bool life = false;
	public int type = 0;
	public float spinSpeed = 0;
	public float speed = 0;
	public float rotZ = 0;

	private float dt = 0;
	private bool chk = false;
	private float onTime = 0;
	private MonsterManager mM = null;
    private GameManager gM;

    void Start () {
        if (gameObject.tag == "Monster")
        {
            player = GameObject.Find("Player");
            Obj = GameObject.Find("Obj");
            gM = Obj.GetComponent<GameManager>();
        }
        if (gameObject.tag == "Boos")
        {
            gM = Obj.GetComponent<GameManager>();
        }
    }
	
	void Update () 
	{
		dt += Time.deltaTime;
		switch (type)
		{
			case 1:
				spin();
				move();
				break;
			case 2:
				Tracking();
				move();
				break;
			case 3:
				if (spinSpeed == 1)
				{
					transform.position += transform.right * speed * Time.deltaTime;
					if (100.0f <= Vector3.Distance(transform.position, player.transform.position))
					{
						Destroy(gameObject);
					}
				}
				else
				{
					Tracking();

					if (40.0f <= Vector3.Distance(transform.position, player.transform.position))
					{
						move();
					}
					else
					{
						if (onTime + 3f <= dt)
						{
							mM = Barrier.GetComponent<MonsterManager>();
							mM.type = 3;
							mM.spinSpeed = 1;
							mM.player = player;
							Barrier.transform.SetParent(Obj.transform);
							Barrier = null;
							onTime = dt;
						}
					}

					if (onTime + 2f <= dt && Barrier == null)
					{
						Barrier = Instantiate(newBarrier);
						Barrier.transform.SetParent(transform);
						Barrier.transform.position = qwe.transform.position;
						Barrier.transform.rotation = qwe.transform.rotation;
					}
				}
				break;
			case 4:
				if (20.0f <= Vector3.Distance(transform.position, player.transform.position) && chk == false)
					move();

				if (8.0f >= Vector3.Distance(transform.position, player.transform.position) && chk == false)
				{
					onTime = dt;
					chk = true;
					shieldOnOff(chk);
				}

				if (onTime + 5f <= dt && chk == true)
				{
					chk = false;
					shieldOnOff(chk);
				}

				if (chk == false)
					Tracking();

				break;
            case 5:
                spin();
                break;
		}

        if (gameObject.tag == "Boos")
        {
            if (gM.killBoos >= 4 && Barrier != null)
            {
                Barrier.SetActive(false);
            }
        }
	}

	void move()
	{
        if (player != null)
		    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	}

	void spin()
	{
		transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
	}

	void Tracking()
	{
        if (player != null)
        {
            float rota = GetAngle(transform.position, player.transform.position);
            if (spinSpeed != 82)
            {
                if (rotZ >= 0)
                {
                    if (rotZ >= rota && rotZ - 180 <= rota)
                        rotZ -= spinSpeed * Time.deltaTime;
                    else
                    {
                        if (rota < 0)
                            rota += 360;
                        if (rotZ <= rota && (rotZ - 180) + 360 >= rota)
                            rotZ += spinSpeed * Time.deltaTime;
                    }
                }
                else if (rotZ < 0)
                {
                    if (rotZ <= rota && rotZ + 180 >= rota)
                        rotZ += spinSpeed * Time.deltaTime;
                    else
                    {
                        if (rota > 0)
                            rota -= 360;
                        if (rotZ > rota && (rotZ + 180) - 360 < rota)
                            rotZ -= spinSpeed * Time.deltaTime;
                    }
                }
                if (rotZ >= 180 || rotZ <= -180)
                    rotZ *= -1;
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rota);
            }
        }
	}

	void shieldOnOff(bool Onf)
	{
		Barrier.SetActive(Onf);
	}

	public float GetAngle(Vector3 vStart, Vector3 vEnd)
	{
		Vector3 v = vEnd - vStart;
		return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col != null)
		{
			PlayerManager pM = col.gameObject.GetComponent<PlayerManager>();
			if (col.tag == "Player" && pM.moveChak == true && life == true || col.tag == "Player" && pM.XXX == true && life == true)
			{
                if (gameObject.tag == "Monster")
                {
				    pM.moveTime = pM.dt - 1f;
                    gM.monNum--;
                    gM.killMon++;

                    diyPart = Instantiate(newPart);
                    diyPart.transform.SetParent(Obj.transform);
                    diyPart.transform.position = new Vector3(transform.position.x, transform.position.y, -1);

                    gM.Sou = true;
                    Destroy(gameObject);
                }
                if (gameObject.tag == "Boos")
                {
                    pM.moveTime = pM.dt - 1f;

                    diyPart = Instantiate(newPart);
                    diyPart.transform.SetParent(Obj.transform);
                    diyPart.transform.position = new Vector3(transform.position.x, transform.position.y, -1);

                    gM.Sou = true;
                    gM.killBoos++;
                    Destroy(gameObject);
                }
            }
            if (col.tag == "cr" && life == true && gameObject.tag == "Monster")
            {
                if (gameObject.tag == "Monster")
                {
                    gM.monNum--;

                    diyPart = Instantiate(newPart);
                    diyPart.transform.SetParent(Obj.transform);
                    diyPart.transform.position = new Vector3(transform.position.x, transform.position.y, -1);

                    gM.Sou = true;
                    Destroy(gameObject);
                }
            }
        }
	}
}