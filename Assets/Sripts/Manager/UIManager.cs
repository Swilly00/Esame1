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
    [SerializeField] Button tNormal;
    [SerializeField] Button tSMG;
    [SerializeField] Button tArea;
    



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
        
        moneyText.text = (money.ToString() + " $");
        if (money < 15)
        {
            
            tNormal.interactable = false;
            tSMG.interactable = false;
            tArea.interactable = false;
            GameManager.instance.turretNormalActiveMoney = false;
            GameManager.instance.turretAreaActiveMoney = false;
            GameManager.instance.turretSMGActiveMoney = false;

        }
        else if (money >= 25)
        {
            tNormal.interactable = true;
            tSMG.interactable = true;
            tArea.interactable = true;
            GameManager.instance.turretNormalActiveMoney = true;
            GameManager.instance.turretAreaActiveMoney = true;
            GameManager.instance.turretSMGActiveMoney = true;
        }
        else if (money >= 20)
        {
            tNormal.interactable = true;
            tSMG.interactable = true;
            tArea.interactable = false;
            GameManager.instance.turretNormalActiveMoney = true;
            GameManager.instance.turretSMGActiveMoney = true;
            GameManager.instance.turretAreaActiveMoney = false;
        }
        else if (money >= 15)
        {
            tNormal.interactable = true;
            tSMG.interactable = false;
            tArea.interactable = false;
            GameManager.instance.turretNormalActiveMoney = true;
            GameManager.instance.turretSMGActiveMoney = false;
            GameManager.instance.turretAreaActiveMoney = false;
        }
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
