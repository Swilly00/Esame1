using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float speed;
    float damage = 5f;


    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        turret.OnChangeDamage += UpdateDamage;
    }
    private void OnDisable()
    {
        turret.OnChangeDamage -= UpdateDamage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
            Destroy(gameObject);
        if(collision.gameObject.TryGetComponent(out IDamageble enemy))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }
    private void UpdateDamage()
    {
        damage *= GameManager.instance.upgradeDamage;
    }
}
