using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public enum GameStatus
    {
        GameRunning,
        GamePaused
    }

    public GameStatus status;
    public static GameManager instance;
    public int enemyDeadCounter = 0;
    [SerializeField] public int startMoney;
    public int currentMoney;
    public float maxHeath = 120f;
    public float currenHealth;
    //Action per dare alla UI l'aggiornameto dei money
    public static event Action<int> OnAddMoney;

    public bool turretNormalActive;
    public bool turretSMGActive;
    public bool turretAreaActive;

    public float upgradeDamage = 2f;
    public float upgradeFireFare = 0.5f;
    public float upgradeArea = 0.75f;











    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;

    }



    private void Start()
    {
        currentMoney = startMoney;
        currenHealth = maxHeath;
        status = GameStatus.GameRunning;

    }

    private void OnEnable()
    {
        Enemy.OnDeathEnemy += AddDeadOnCounter;
        Enemy.OnDeathEnemy += AddMoney;
        turret.OnUpgradeTurret += RemoveMoney;
        TurretSpawn.OnBuildTurret += RemoveMoney;
    }

    private void OnDisable()
    {
        Enemy.OnDeathEnemy -= AddDeadOnCounter;
        Enemy.OnDeathEnemy -= AddMoney;
        turret.OnUpgradeTurret -= RemoveMoney;
        TurretSpawn.OnBuildTurret -= RemoveMoney;
    }
    private void Update()
    {
        if (status == GameStatus.GameRunning)
            GameStatusRun();
        else
            GameStatusPause();
    }

    private void AddDeadOnCounter(int n)
    {
        enemyDeadCounter++;
    }

    private void AddMoney(int money)
    {
        currentMoney += money;
        OnAddMoney?.Invoke(currentMoney);

    }
    private void RemoveMoney(int money)
    {
        currentMoney -= money;
        OnAddMoney?.Invoke(currentMoney);
    }
    public void GameStatusRun()
    {
        Time.timeScale = 1.0f;
    }
    public void GameStatusPause()
    {
        Time.timeScale = 0.0f;
    }

    public void ButtonTNormal()
    {
        turretNormalActive = true;
        turretSMGActive = false;
        turretAreaActive = false;
    } 

    public void ButtonSMGNormal()
    {
        turretNormalActive = false;
        turretSMGActive = true;
        turretAreaActive = false;
    } 

    public void ButtonAreaNormal()
    {
        turretNormalActive = false;
        turretSMGActive = false;
        turretAreaActive = true;
    } 
    
}
