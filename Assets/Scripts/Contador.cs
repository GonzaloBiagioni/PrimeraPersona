using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public float timer = 0;
    public Text textotimer;

        void Update()
    {
        timer -= Time.deltaTime;
        textotimer.text = ""+ timer.ToString("f0");

        if (timer < 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
    }
}
