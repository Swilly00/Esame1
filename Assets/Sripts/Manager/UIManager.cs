using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] TMP_Text moneyText;
    [SerializeField] Image fillHealthBar;
    [SerializeField] GameObject endPanel;
    [SerializeField] TMP_Text killedEnemy;



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
        moneyText.text = (GameManager.instance.startMoney.ToString() + " $");
    }
    private void OnEnable()
    {
        GameManager.OnAddMoney += SetMoneyUI;
        Enemy.OnBaseDamage += SetHealthBar;
    }
    private void OnDisable()
    {
        GameManager.OnAddMoney -= SetMoneyUI;
        Enemy.OnBaseDamage -= SetHealthBar;
    }
    private void SetMoneyUI(int money)
    {
        moneyText.text = (money.ToString()+ " $");
    }
    private void SetHealthBar(float damage)
    {
        GameManager.instance.currenHealth -= damage;
        fillHealthBar.fillAmount = (GameManager.instance.currenHealth / GameManager.instance.maxHeath);
        if (GameManager.instance.currenHealth <= 0)
        {
            GameManager.instance.status = GameManager.GameStatus.GamePaused;
            endPanel.gameObject.SetActive(true);
            killedEnemy.text = ("Enemy uccisi: " + GameManager.instance.enemyDeadCounter);
        }
    }




}
