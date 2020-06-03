using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControls : MonoBehaviour
{
    private readonly int speed = 3;
    [SerializeField]
    public GameObject enemyExplosionPrefab;
    [SerializeField]
    public AudioClip explosionSound;
    
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -6.6f)
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 6.6f, 0);
            ScoreView.score -= 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameObject objectFireExplosion = (GameObject)Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
            Destroy(objectFireExplosion, 2.5f);
            ScoreView.score += 10;
        }
        else if (collision.CompareTag("Asteroid"))
        {
            Destroy(this.gameObject);
            GameObject objectAsteroidExplosion = (GameObject)Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
            Destroy(objectAsteroidExplosion, 2.5f);
        }
        else if (collision.CompareTag("Player"))
        {
            PlayerControls playerControls = collision.GetComponent <PlayerControls>();

            if (playerControls != null)
            {
                playerControls.LifeSubstraction();
            }
            GameObject objectPlayerExplosion = (GameObject)Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);            
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
            Destroy(this.gameObject);
            Destroy(objectPlayerExplosion, 2.5f);            
            ScoreView.score += 10;
        }
    }
}
