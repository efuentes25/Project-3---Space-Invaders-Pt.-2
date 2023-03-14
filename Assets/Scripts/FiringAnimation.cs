using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringAnimation : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject fireBulletPrefab;

    public AudioSource fireSoundEffect;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireSoundEffect.Play();
            //Instantiate(fireBulletPrefab, transform.position, Quaternion.identity);
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
