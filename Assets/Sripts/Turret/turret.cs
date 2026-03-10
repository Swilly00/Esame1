using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public abstract class turret : MonoBehaviour, IPointerClickHandler
{

    int moneyForUpgrate = 30;
    private int upgrateState;
    private int upgrateStateCount;
    public int turretType; //1:Normal 2:SMG 3:Area

    public static event Action OnChangeFireRate;
    public static event Action OnChangeDamage;
    public static event Action OnChangeArea;
    public static event Action<int> OnUpgradeTurret;


    public virtual void Start()
    {
        upgrateState = 0;
        upgrateStateCount = 0;
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.instance.currentMoney >= moneyForUpgrate && (upgrateStateCount != 7))
        {
            OnUpgradeTurret?.Invoke(moneyForUpgrate);
            moneyForUpgrate *= 2;
            upgrateState++;
            switch (upgrateState)
            {
                case 0:
                    break;
                case 1:
                        upgrateStateCount++;

                        if (turretType == 1)
                        {
                            OnChangeDamage?.Invoke();
                            upgrateState--;
                            break;
                        }
                        else if (turretType == 2)
                        {
                            OnChangeFireRate?.Invoke();
                            upgrateState--;
                            break;
                        }
                        else
                        {
                            OnChangeArea?.Invoke();
                            upgrateState--;
                            break;
                        }

                    
                    




            }

        }
    }

}
