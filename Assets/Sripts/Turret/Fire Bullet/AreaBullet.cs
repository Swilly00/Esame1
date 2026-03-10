using UnityEngine;

public class AreaBullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float speed;
    float damage = 15f;
    [SerializeField]float areaRadius;
    [SerializeField]private LayerMask mask;


    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        turret.OnChangeArea += UpdateArea;

    }
    private void OnDisable()
    {
        turret.OnChangeArea -= UpdateArea;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
            Destroy(gameObject);

        Collider[] hit = Physics.OverlapSphere(transform.position, areaRadius, mask);
        foreach(Collider c in hit)
        {
            
            if(c.TryGetComponent(out IDamageble enemy))
            {
                enemy.TakeDamage(damage);
            }
        }
        Destroy(gameObject);

    }
    private void UpdateArea()
    {
        areaRadius *= GameManager.instance.upgradeArea;
    }
}

