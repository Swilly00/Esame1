using UnityEngine;
using System;

public  class Enemy : MonoBehaviour, IDamageble
{
    enum EnemyType
    {
        runner,
        tank
    }
    [SerializeField]EnemyType enemyType;
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private int moneyDrops;
    [SerializeField] private float damageBase;
    private float currentHealth;
    private Color runnerColor = Color.rebeccaPurple;
    private Color tankColor = Color.rosyBrown;
    private Renderer material;
    //Action la quale andra alla GameManager 
    public static event Action<int> OnDeathEnemy;
    //Action che andra alla UIManager quando un nemico va a contatto con la base
    public static event Action<float> OnBaseDamage;


    private void Start()
    {
        currentHealth = health;
        
        material = GetComponent<Renderer>();

        //Dal tipo di Enemy lo colora
        if(enemyType == EnemyType.runner)
            material.material.color = runnerColor;
        else material.material.color = tankColor;
            
    }
    public  void Update()
    {
        //Movimento del Enemy
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        health += 0.1f * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
            Death();
    }

    public void Death()
    {
        OnDeathEnemy?.Invoke(moneyDrops);
        Destroy(gameObject);
    }

    public void BaseDamage()
    {
        OnBaseDamage?.Invoke(damageBase);
        Destroy(gameObject);
    }
}
