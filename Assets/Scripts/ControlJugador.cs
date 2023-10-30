using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ControlJugador : MonoBehaviour
{
    public float jumpForce = 10f;
    private bool isGrounded = true;
    private Rigidbody rb;
    public float rapidezDesplazamiento = 8.0f;
    public GameObject bala;
    public Transform spawnerbala;
    public float fuerzabala;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento; 
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento; 
        movimientoAdelanteAtras *= Time.deltaTime; movimientoCostados *= Time.deltaTime; 
        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras); 

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Input.GetMouseButtonDown (0))
        {
            shooting();
        }
        if (Input.GetKeyDown("escape")) 
        { 
            Cursor.lockState = CursorLockMode.None; 
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Final"))
        {
            SceneManager.LoadScene(1);
        }
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
    }
    void shooting()
    {
        GameObject bulletClone = Instantiate(bala, spawnerbala.position, spawnerbala.rotation);
        Rigidbody bulletRB = bulletClone.GetComponent<Rigidbody>();
        bulletRB.AddRelativeForce(Vector3.forward * fuerzabala, ForceMode.Impulse);
    }
}




