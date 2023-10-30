using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float BulletSpawnedTime;
    public float BulletDespawnTime;
    void Update()
    {
        BulletSpawnedTime += Time.deltaTime;
        if (BulletSpawnedTime >= BulletDespawnTime)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Destroy(this.gameObject);
        }
    }

}
