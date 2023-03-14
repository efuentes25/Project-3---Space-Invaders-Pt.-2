using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float bulletSpeed = 5f;
    private ScoreManager scoreManager;
    public int pointsMax = 300;
    public int pointsMin = 50;
    public int randomPoints;

    public GameObject explosionPrefab;

    public AudioClip explosionSoundEffect;
    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        randomPoints = Random.Range(pointsMin, pointsMax);
    }
    
    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy1"))
        {
            AudioSource.PlayClipAtPoint(explosionSoundEffect, transform.position);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            scoreManager.UpdateScore(10);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy2"))
        {
            AudioSource.PlayClipAtPoint(explosionSoundEffect, transform.position);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            scoreManager.UpdateScore(20);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy3"))
        {
            AudioSource.PlayClipAtPoint(explosionSoundEffect, transform.position);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            scoreManager.UpdateScore(30);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy4"))
        {
            AudioSource.PlayClipAtPoint(explosionSoundEffect, transform.position);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            scoreManager.UpdateScore(randomPoints);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Barricade"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
