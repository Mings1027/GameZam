using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform seaOtter;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed;

    private void Start()
    {
        offset = transform.position + new Vector3(0, 0, -10);
    }

    private void LateUpdate()
    {
        var changedPos = seaOtter.position + offset;
        var smoothedPos = Vector3.Lerp(transform.position, changedPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPos;
    }
}
