using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
    }
}