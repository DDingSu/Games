using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject pM = null;

    public int stage = 0;

    public GameObject[] boos = null;

    // 몬스터 최대수
    public int monMax = 0;
    // 몬스터 수
    public int monNum = 0;
    // 몬스터 죽일수
    public int killMonMax = 0;
    // 몬스터 죽인수
    public int killMon = 0;
    // 몬스터 죽인수
    public int killBoos = 0;

    // 스폰 위치    8
    public GameObject[] spawn = null;
    public SpawnManager[] spawnManager = null;

    public Text stageT = null;
    public GameObject Cr = null;
    public GameObject SinE = null;
    private SinEManager SinEM = null;
    public AudioClip DiySound = null;

    private AudioSource audio = null;
    private int spawnRnum = 0;
    private float dt = 0;
    private float spawnT = 3;
    private bool monRanSetOn = true;
    private float SpawnD = 1.0f;
    private PlayerManager pManager = null;
    private bool qwe = true;
    private float tCount = 0;
    private bool asd = true;
    public bool Sou = false;

    void Start () {
        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = DiySound;
        audio.loop = false;

        SinE.SetActive(true);
        DontDestroyOnLoad(this);
        for (int i = 0; i < 8; i++)
        {
            spawnManager[i] = spawn[i].GetComponent<SpawnManager>();
        }
        pManager = pM.GetComponent<PlayerManager>();
        SinEM = SinE.GetComponent<SinEManager>();
    }

    void Update () {
        dt += Time.deltaTime;

        if (dt > 2.5f && asd == true)
        {
            SinE.SetActive(false);
        }

        if (dt >= 1.5f && pM != null && qwe == true)
        {
            pM.SetActive(true);
            qwe = false;
        }

        if (pM != null)
        {
            spawnPoint();
            monSet();
        }

        if (tCount > 0)
        {
            tCount += Time.deltaTime;
        }

        if (tCount > 1.5f)
        {
            SinEM.type = 2;
        }

        if (tCount > 3f)
        {
            tCount = 0;
            SceneManager.LoadScene(1);
        }

        if ((pManager.life == false && asd == true) || killBoos == 5)
        {
            killBoos = 6;
            asd = false;
            tCount = 0.1f;
            SinE.SetActive(true);
        }

        if (Sou == true)
        {
            audio.Play();
            Sou = false;
        }
    }

    void spawnPoint()
    {
        if (monMax > monNum && spawnT + SpawnD < dt)
        {
            spawnT = dt;
            monNum++;
            spawnRnum = Random.Range(0, 8);
            switch (spawnRnum)
            {
                case 0:
                    spawnManager[0].onOff = true;
                    break;
                case 1:
                    spawnManager[1].onOff = true;
                    break;
                case 2:
                    spawnManager[2].onOff = true;
                    break;
                case 3:
                    spawnManager[3].onOff = true;
                    break;
                case 4:
                    spawnManager[4].onOff = true;
                    break;
                case 5:
                    spawnManager[5].onOff = true;
                    break;
                case 6:
                    spawnManager[6].onOff = true;
                    break;
                case 7:
                    spawnManager[7].onOff = true;
                    break;
            }
        }
    }

    void monSet()
    {
        switch (stage)
        {
            case 1:
                if (monRanSetOn)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        spawnManager[i].monRan[0] = 50;
                        spawnManager[i].monRan[1] = 15;
                        spawnManager[i].monRan[2] = 35;
                        spawnManager[i].monRan[3] = 0;
                        spawnManager[i].monRan[4] = 0;
                    }
                    monRanSetOn = false;
                }
                if (killMon >= killMonMax)
                {
                    killMon = killMonMax;
                    killMonMax += 6;
                    monRanSetOn = true;
                    Cr.SetActive(true);
                    stage++;
                    stageT.text = stage + "";
                }
                break;
            case 2:
                if (monRanSetOn)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        spawnManager[i].monRan[0] = 45;
                        spawnManager[i].monRan[1] = 15;
                        spawnManager[i].monRan[2] = 40;
                        spawnManager[i].monRan[3] = 0;
                        spawnManager[i].monRan[4] = 0;
                    }
                    monRanSetOn = false;
                }
                if (killMon >= killMonMax)
                {
                    killMon = killMonMax;
                    killMonMax += 6;
                    monRanSetOn = true;
                    Cr.SetActive(true);
                    stage++;
                    stageT.text = stage + "";
                }
                break;
            case 3:
                if (monRanSetOn)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        spawnManager[i].monRan[0] = 40;
                        spawnManager[i].monRan[1] = 10;
                        spawnManager[i].monRan[2] = 25;
                        spawnManager[i].monRan[3] = 25;
                        spawnManager[i].monRan[4] = 0;
                    }
                    monRanSetOn = false;
                }
                if (killMon >= killMonMax)
                {
                    killMon = killMonMax;
                    killMonMax += 6;
                    monRanSetOn = true;
                    Cr.SetActive(true);
                    stage++;
                    stageT.text = stage + "";
                }
                break;
            case 4:
                if (monRanSetOn)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        spawnManager[i].monRan[0] = 20;
                        spawnManager[i].monRan[1] = 10;
                        spawnManager[i].monRan[2] = 25;
                        spawnManager[i].monRan[3] = 25;
                        spawnManager[i].monRan[4] = 20;
                    }
                    monRanSetOn = false;
                }
                if (killMon >= killMonMax)
                {
                    killMon = killMonMax;
                    killMonMax += 6;
                    monRanSetOn = true;
                    Cr.SetActive(true);
                    stage++;
                    stageT.text = stage + "";
                }
                break;
            case 5:
                if (monRanSetOn)
                {
                    pM.transform.position = new Vector2(0, -15);
                    pManager.Ppoint = pM.transform.position;
                    boos[0].SetActive(true);
                    SpawnD = 2.0f;
                    for (int i = 0; i < 8; i++)
                    {
                        spawnManager[i].monRan[0] = 20;
                        spawnManager[i].monRan[1] = 10;
                        spawnManager[i].monRan[2] = 25;
                        spawnManager[i].monRan[3] = 25;
                        spawnManager[i].monRan[4] = 20;
                    }
                    monRanSetOn = false;
                }
                break;
        }
    }
}