using UnityEngine;

public class BossBreath : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = GameObject.Find("SeaOtter").GetComponent<SeaOtterController>().moveSpeed - 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
            Time.timeScale = 0f;
        }
    }
}
