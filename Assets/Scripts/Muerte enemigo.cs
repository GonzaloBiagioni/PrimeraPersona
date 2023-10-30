using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerteenemigo : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            Destroy(this.gameObject);
        }
    }

}

