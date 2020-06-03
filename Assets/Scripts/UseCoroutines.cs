using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCoroutines : MonoBehaviour
{
    public GameObject batPrefab;
    public GameObject asteroidPrefab;
    public GameObject bootsPrefab;
    public GameObject bottlePrefab;
    public GameObject heartPrefab;
    public GameObject coinPrefab;
    private float heartLastSpawnTime;
    private float coinLastSpawnTime;
    
    void Start()
    {
        StartCoroutine(CloneEnemyPrefab());
        heartLastSpawnTime = Time.time;
        coinLastSpawnTime = Time.time;
    }

    IEnumerator CloneEnemyPrefab()
    {
        while (true)
        {
            Instantiate(batPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 6.6f, 0), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);            
            Instantiate(bootsPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 6.6f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
            Instantiate(bottlePrefab, new Vector3(Random.Range(-8.0f, 8.0f), 6.6f, 0), Quaternion.identity);
            yield return new WaitForSeconds(4.0f);
            GameObject objectAsteroid = (GameObject)Instantiate(asteroidPrefab, new Vector3(10.0f, Random.Range(-3.5f, 3.5f), 0), Quaternion.identity);
            yield return new WaitForSeconds(13.0f);
            Destroy(objectAsteroid, 7.0f);
            if (PlayerControls.playerLives < 5)
            {
                float timeInterval = Time.time - heartLastSpawnTime;
                if (timeInterval > Random.Range(120.0f, 180.0f))
                {
                    GameObject objectHeart = (GameObject)Instantiate(heartPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 6.6f, 0), Quaternion.identity);
                    yield return new WaitForSeconds(10.0f);
                    Destroy(objectHeart, 8.0f);
                    heartLastSpawnTime = Time.time;
                }
                
            }
            if (ScoreView.score < 0)
            {
                float timeInterval = Time.time - coinLastSpawnTime;
                if (timeInterval > Random.Range(60.0f, 120.0f))
                {
                    GameObject objectCoin = (GameObject)Instantiate(coinPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 6.6f, 0), Quaternion.identity);
                    yield return new WaitForSeconds(0.0f);
                    Destroy(objectCoin, 8.0f);
                    coinLastSpawnTime = Time.time;
                }
            }
            else
            {
                float timeInterval = Time.time - coinLastSpawnTime;
                if (timeInterval > Random.Range(120.0f, 180.0f))
                {
                    GameObject objectGold = (GameObject)Instantiate(coinPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 6.6f, 0), Quaternion.identity);
                    yield return new WaitForSeconds(0.0f);
                    Destroy(objectGold, 8.0f);
                    coinLastSpawnTime = Time.time;
                }
            }

        }
    }
}
