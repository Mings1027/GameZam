using GameControl;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Transform seaOtter;
    [SerializeField] private float startTime, repeatTime;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnFood), startTime, repeatTime);
    }

    private void SpawnFood()
    {
        var seaOtterPosition = seaOtter.position;
        var ranPosition = new Vector3(seaOtterPosition.x + 20,
            GameManager.Instance.BackgroundMinY + 5, 0);
        var ranRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        ObjectPoolManager.Get("Food", ranPosition, ranRotation);
    }

}