using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float waitTime = 3f;
    public GameObject explosionPrefab;

    public AudioClip explosionSoundEffect;

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalAxis * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Enemy1") 
            || collision.collider.gameObject.CompareTag("Enemy2") 
            || collision.collider.gameObject.CompareTag("Enemy3") 
            || collision.collider.gameObject.CompareTag("Enemy4"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            AudioSource.PlayClipAtPoint(explosionSoundEffect, transform.position);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene("Credits");
            
            //StartCoroutine(GameOver());
        }
    }
    
    private IEnumerator<WaitForSeconds> GameOver()
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("we hit");
        SceneManager.LoadScene("Credits");

    }
    
}
