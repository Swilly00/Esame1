using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision != null)
        {
            collision.gameObject.TryGetComponent(out IDamageble damageble);
            damageble.BaseDamage();
        }
    }
}
