using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsControls : MonoBehaviour
{
    private readonly int speed = 5;
    [SerializeField]
    public GameObject enemyExplosionPrefab;
    [SerializeField]
    public AudioClip explosionSound;
    private int flag = 0;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -6.6f || transform.position.x < -13.0f || 
            transform.position.x > 10.0f)
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 6.6f, 0);
            ScoreView.score -= 20;
        }
    }

    private void FixedUpdate()
    {
        /*Quaternion rotationY = Quaternion.AngleAxis(1, Vector3.down);
        transform.rotation *= rotationY;*/
        flag = Random.Range(0, 2);
        if (flag == 0)
        {
            transform.Rotate(new Vector3(0, 0, 1));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -1));
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
            ScoreView.score += 20;
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
            PlayerControls playerControls = collision.GetComponent<PlayerControls>();

            if (playerControls != null)
            {
                playerControls.LifeSubstraction();
            }
            GameObject objectPlayerExplosion = (GameObject)Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);            
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
            Destroy(this.gameObject);
            Destroy(objectPlayerExplosion, 2.5f);
            ScoreView.score += 20;
        }
    }
}
