using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour 
{
	public GameObject camera = null;
	public float speed = 0;
	public bool moveChak = false;
    public GameObject Obj = null;
    public GameObject XXXPart = null;
    public ParticleSystem newPart = null;
    public ParticleSystem diyPart = null;
    public bool life = true;
    private float startTime;
	private float journeyLength;
    public Vector2 Ppoint = Vector2.zero;
	private Rigidbody2D rig;
	private float distCovered = 0;
	private float fracJourney = 0;
    public bool XXX = false;
    public GameObject Cous = null;
    private cursorManager CousM = null;
    public Texture2D cou1 = null;
    public Texture2D cou2 = null;

    private int num = 0;
	public float dt = 0;
	public float moveTime = -1;
    private GameManager gM;

    void Start () 
	{
        if (Obj != null)
            gM = Obj.GetComponent<GameManager>();

        if (Cous != null)
            CousM = Cous.GetComponent<cursorManager>();

        Ppoint = transform.position;
		rig = GetComponent<Rigidbody2D>();
	}
	
	void Update () 
	{
		dt += Time.deltaTime;


        float Hi = 0f;
        if (camera == null)
            Hi = 0f;
        else
            Hi = 1f;

        if (XXXPart != null)
        {
            XXXPart.transform.position = transform.position;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                XXX = true;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                XXX = false;
            }
            if (XXX == true)
            {
                XXXPart.SetActive(true);
            }
            else
            {
                XXXPart.SetActive(false);
            }
        }

        if (moveTime + Hi < dt)
        {
            CousM.cursorTexture = cou2;
            CousM.StartCoroutine("MyCursor");
        }

        if (Input.GetMouseButtonDown(0) && moveTime + Hi < dt)
		{
            CousM.cursorTexture = cou1;
            CousM.StartCoroutine("MyCursor");
            moveChak = true;

			Ppoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			startTime = Time.time;
			journeyLength = Vector3.Distance(transform.position, Ppoint); // 두점 사이의 거리
			num++;
			moveTime = dt;
		}

		if (Ppoint == (Vector2)transform.position)
			moveChak = false;

		if (num > 0 && (Vector2)transform.position != Ppoint)
		{
			distCovered = (Time.time - startTime) * speed; //속력 v = m/s 1초에 10움직임 한프레임당 1움직인다고하면
			fracJourney = distCovered / journeyLength; // 속력 / 길이 = m/s / m = 1/s 시간 fracJourney = 0.1f
			transform.position = Vector3.Lerp(transform.position, Ppoint, fracJourney);
		}

		if ((Vector2)transform.position == Ppoint && num > 0 && camera != null)
		{
			camera.SendMessage("moveCamera", transform.position);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col != null)
		{
            if (XXX == false)
            {
                if (col.tag == "Barrier" || (moveChak == false && col.tag == "Monster"))
                {
                    gM.Sou = true;
                    diyPart = Instantiate(newPart);
                    diyPart.transform.SetParent(Obj.transform);
                    diyPart.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
                    Ppoint = transform.position;
                    life = false;
                    moveChak = false;
                    gameObject.SetActive(false);
                }
            }
		}
	}
}