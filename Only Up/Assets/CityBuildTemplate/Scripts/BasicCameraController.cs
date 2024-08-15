using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCameraController : MonoBehaviour
{

    public float speed;
    public float scrollSpeed;
    public float rotationSpeed;
    GameObject cam;

    private void Start()
    {
        cam = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float w = Input.mouseScrollDelta.y;

        if (h != 0|| v != 0)
        {
            transform.Translate(new Vector3(h * speed * Time.deltaTime, 0f, v * speed * Time.deltaTime));
        }


        if (w != 0)
        {
            cam.transform.Translate(new Vector3(0f, 0f, w * scrollSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
        }

    }
}
