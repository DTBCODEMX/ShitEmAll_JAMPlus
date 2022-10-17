using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField] public GameObject[] obstaculos;
    public float minTime = 2f;
    public float maxTime = 4f;
    public float EnemyWave = 5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }
    private float cont = 0;
    // Update is called once per frame
    private IEnumerator SpawnObstacle()
    {




       
        while (cont < EnemyWave)
        {
            int randomIndex = Random.Range(0, obstaculos.Length);

            float randomTime = Random.Range(minTime, maxTime);
            Instantiate(obstaculos[randomIndex], transform.position, Quaternion.identity);
            cont += 1;
            yield return new WaitForSeconds(randomTime);
        }
    }
    
}