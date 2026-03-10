using NUnit.Framework;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Enemy = new GameObject[0];
    [SerializeField] float rate;
    float timer;
    int randomNum;
    int counter;
    [SerializeField] float minRate;
    [SerializeField] int BeforeChangeRate;
    [SerializeField] float chengedRate;
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= rate)
        {
            randomNum = Random.Range(0, Enemy.Length);
            Instantiate(Enemy[randomNum], transform.position, transform.rotation, transform);
            counter++;
            if (counter % BeforeChangeRate == 0 && counter != 0 && rate >= minRate)
                rate -= chengedRate;
            timer = 0;
        }
    }


}
