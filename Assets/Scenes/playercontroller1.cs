using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller1 : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
    {SceneManager.LoadScene("Mode");
    }
    }
}
