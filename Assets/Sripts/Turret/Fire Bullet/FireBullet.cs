using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float rate;
    float timer;

    private void OnEnable()
    {
        turret.OnChangeFireRate += ChangeFireRite;
    }
    private void OnDisable()
    {
        turret.OnChangeFireRate -= ChangeFireRite;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= rate)
        {
            Instantiate(bullet, transform.position, transform.rotation, transform);
            timer = 0;
        }
    }
    private void ChangeFireRite()
    {
        
        rate -= GameManager.instance.upgradeFireFare;
    }
}
