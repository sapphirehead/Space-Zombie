using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControls : MonoBehaviour
{
    private readonly int fireSpeed = 6;//public

    void Update()
    {
        transform.Translate(Vector3.up * fireSpeed * Time.deltaTime);

        if(transform.position.y >= 5.9)
        {
            Destroy(this.gameObject, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            //Destroy(collision.gameObject);
            Destroy(this.gameObject);
            /*GameObject objectFireExplosion = (GameObject)Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
            Destroy(objectFireExplosion, 2.5f);*/
        }
    }
}
