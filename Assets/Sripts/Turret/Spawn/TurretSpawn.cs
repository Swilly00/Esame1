using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretSpawn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject[] turretList;
    private GameObject turret;
    bool Active;

    public static event Action<int> OnBuildTurret;
    private void Start()
    {
        Active = true; 
        GetComponent<Renderer>().material.color = Color.white;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (Active)
        {
            Debug.Log("ciao");
            if (GameManager.instance.turretNormalActive && GameManager.instance.turretNormalActive)
            {
                turret = Instantiate(turretList[0], new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), transform.localRotation, transform);
                OnBuildTurret?.Invoke(15);
                GetComponent<Renderer>().material.color = Color.rebeccaPurple;
                Active = false;
            }
            else if (GameManager.instance.turretSMGActive && GameManager.instance.turretSMGActiveMoney)
            {
                turret = Instantiate(turretList[1], new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), transform.localRotation, transform);
                OnBuildTurret?.Invoke(20);
                GetComponent<Renderer>().material.color = Color.rebeccaPurple;
                Active = false;
            }
            else if (GameManager.instance.turretAreaActive && GameManager.instance.turretAreaActiveMoney)
            {
                turret = Instantiate(turretList[2], new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), transform.localRotation, transform);
                OnBuildTurret?.Invoke(25);
                GetComponent<Renderer>().material.color = Color.rebeccaPurple;
                Active = false;
            }
        }
    }
}
