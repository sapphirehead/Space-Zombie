using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControls : MonoBehaviour
{
    private readonly int speed = 10;
    [SerializeField]
    public GameObject enemyExplosionPrefab;
    [SerializeField]
    public AudioClip coinSound;
    public AudioClip fireSound;
    public AudioClip accidentSound;
    private readonly int rotateSpeed = 2;

    void Update()
    {
        Vector3 direction = Vector3.down * speed * Time.deltaTime;
        transform.position += direction * speed * Time.deltaTime;
        transform.Rotate(0, 0, rotateSpeed);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameObject objectFireExplosion = (GameObject)Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(fireSound, Camera.main.transform.position, 1.0f);
            Destroy(objectFireExplosion, 2.5f);

        }
        else if (collision.CompareTag("Asteroid"))
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(accidentSound, Camera.main.transform.position, 1.0f);
            
        }
        else if (collision.CompareTag("Player"))
        {
            PlayerControls playerControls = collision.GetComponent<PlayerControls>();

            if (playerControls != null)
            {
                ScoreView.score += 100;
            }
            AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position, 1.0f);
            Destroy(this.gameObject);

        }
    }
}
