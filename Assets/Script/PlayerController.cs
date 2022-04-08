using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Camera MainCamera;

    void Start()
    {
        MainCamera = Camera.main;
        MainCamera.transform.SetParent(transform);
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        float speed = 10f;
        float spinSpeed = 100f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.eulerAngles = new Vector3(0, horizontal * spinSpeed * Time.deltaTime + transform.eulerAngles.y, 0);
        transform.position += transform.forward * vertical * speed * Time.deltaTime;
    }

}
