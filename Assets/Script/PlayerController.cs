using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Camera MainCamera;
    [SerializeField]
    float speed;
    [SerializeField]
    float XspinSensitivity;
    [SerializeField]
    float YspinSensitivity;

    float mouseX = 0;
    float mouseY = 0;
    float score = 0;
    void Start()
    {
        MainCamera = Camera.main;
        MainCamera.transform.SetParent(transform);
    }

    void Update()
    {
        GetMoveInput();
        GetAttackInput();
        GetScore();
    }

    void GetMoveInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        mouseX += Input.GetAxis("Mouse X") * XspinSensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * YspinSensitivity;
        mouseY = Mathf.Clamp(mouseY, -40.0f, 40.0f);
        Vector3 moveVec = new Vector3(horizontal, 0, vertical);

        transform.eulerAngles = new Vector3(0, mouseX, 0);
        MainCamera.transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
        transform.position += transform.TransformDirection(moveVec) * speed * Time.deltaTime; 
    }

    void GetAttackInput() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 vec = Input.mousePosition;
            vec.z = MainCamera.farClipPlane;
            vec = MainCamera.ScreenToWorldPoint(vec).normalized;
            RaycastHit hit;
            if (Physics.Raycast(MainCamera.transform.position, vec, out hit, 500, 1 << LayerMask.NameToLayer("Target"))) {
                //Debug.DrawRay(MainCamera.transform.position, vec * 1000, Color.red, 10f);
                score += hit.transform.GetComponent<Target>().Shooted();
            }
        }
    }
    void GetScore() {
        if (Input.GetMouseButton(1)) {
            Debug.Log("Your current score : " + (int)score);
        }
    }
}
