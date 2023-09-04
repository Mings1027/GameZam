using System;
using GameControl;
using UnityEngine;
using TMPro;

public class TimerController : Singleton<TimerController>
{
    public Transform bossTransform;
    public TMP_Text timeText;
    public GameObject Timer;
    public GameObject Player;
    public GameObject Boss;
    private float time;

    [SerializeField] private GameObject oil;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject breatheBar;

    // Start is called before the first frame update
    private void Awake()
    {
        bossTransform = Instantiate(Boss, new Vector3(Player.transform.position.x - 35, 3, 0), Quaternion.identity)
            .transform;
        bossTransform.gameObject.SetActive(false);
    }

    private void Start()
    {
        BossStart();
        Timer.SetActive(true);
        Invoke(nameof(RoundClear), 30);
    }

    // Update is called once per frame
    private void Update()
    {
        time -= Time.deltaTime;
        timeText.text = Mathf.CeilToInt(time).ToString();
        //Round_Clear();
    }

    public void BossStart()
    {
        if (time <= 0)
        {
            time = 30;
            Player.GetComponent<SeaOtterController>().moveSpeed = 15f;

            bossTransform.gameObject.SetActive(true);
            GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>().enabled = false;

            Player.GetComponent<Breathe>().OnDisable();
            oil.SetActive(false);
            Player.GetComponent<Health>().OnDisable();
            GameObject.FindGameObjectWithTag("MiniMapUI").SetActive(false);
            GameObject.FindGameObjectWithTag("MiniMapImage").SetActive(false);
            healthBar.SetActive(false);
            breatheBar.SetActive(false);
        }
    }

    public void RoundClear()
    {
        GameManager.Instance.GameClear();
    }
}