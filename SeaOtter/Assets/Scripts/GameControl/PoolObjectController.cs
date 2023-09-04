using UnityEngine;

namespace GameControl
{
    [DisallowMultipleComponent]
    public class PoolObjectController : MonoBehaviour
    {
        [SerializeField] private float lifeTime;

        private void OnEnable()
        {
            Invoke(nameof(DestroyObject), lifeTime);
        }

        private void OnDisable()
        {
            if (IsInvoking())
            {
                CancelInvoke();
            }

            ObjectPoolManager.ReturnToPool(gameObject);
        }

        private void DestroyObject()
        {
            gameObject.SetActive(false);
        }
    }
}