using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    public float speed = 5f;
    // Start is called before the first frame update
public void Start(){

}

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 pos = transform.position;

        pos.x += h * speed * Time.deltaTime;
        transform.position = pos;



    }
} // class
