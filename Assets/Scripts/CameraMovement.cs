using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class CameraMovement : MonoBehaviour
{
    public Vector3 leftRotation;
    public Vector3 frontRotation;
    public Vector3 rightRotation;

    public float rotationSpeed = 45.0f;
    public float cooldownTime = 1.0f;

    Vector3 targetRotation;
    float lastChangeTime;

    Vector3 mousePosition;
    float screenWidth;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        targetRotation = frontRotation;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        screenWidth = Screen.width;

        Debug.Log(transform.localRotation);

        if (mousePosition.x < screenWidth * 0.1f && transform.localRotation.y > frontRotation.y)
        {
            RotateCamera(-rotationSpeed);
        }
        else if (mousePosition.x > screenWidth * 0.9f && transform.localRotation.y < rightRotation.y)
        {
            RotateCamera(rotationSpeed);
        }
    }

    void RotateCamera(float direction)
    {
        // Rotar alrededor del eje Y
        transform.Rotate(0, direction * Time.deltaTime, 0);
    }

}
*/
public class CameraMovement : MonoBehaviour
{
    public Vector3 leftRotation;
    public Vector3 frontRotation;
    public Vector3 rightRotation;

    public float rotationSpeed = 45.0f;
    public float cooldownTime = 1.0f;

    Vector3 targetRotation;
    float lastChangeTime;

    Vector3 mousePosition;
    float screenWidth;
    [SerializeField] GameObject lights;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        targetRotation = frontRotation;
    }
    /*
    private void OnEnable()
    {
        EventManager.OnSpeak += DoSomething;
    }
    private void OnDisable()
    {
        EventManager.OnSpeak -= DoSomething;
    }
    */
    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        screenWidth = Screen.width;

        if(Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.anyKeyDown && !Input.GetKey(KeyCode.Space))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Time.time - lastChangeTime >= cooldownTime)
        {
            Vector3 newTargetRotation = targetRotation;

            // Cambiar la rotación objetivo dependiendo de la posición del ratón
            if (mousePosition.x < screenWidth * 0.1f && transform.rotation == Quaternion.Euler(frontRotation) || Input.GetKeyDown(KeyCode.A) && transform.rotation == Quaternion.Euler(frontRotation) || Input.GetKeyDown(KeyCode.LeftArrow) && transform.rotation == Quaternion.Euler(frontRotation)) // 30% izquierdo
            {
                newTargetRotation = leftRotation;
            }
            else if (mousePosition.x < screenWidth * 0.1f && transform.rotation == Quaternion.Euler(rightRotation) || Input.GetKeyDown(KeyCode.A) && transform.rotation == Quaternion.Euler(rightRotation) || Input.GetKeyDown(KeyCode.LeftArrow) && transform.rotation == Quaternion.Euler(rightRotation))
            {
                newTargetRotation = frontRotation;
            }
            else if (mousePosition.x > screenWidth * 0.9f && transform.rotation == Quaternion.Euler(frontRotation) || Input.GetKeyDown(KeyCode.D) && transform.rotation == Quaternion.Euler(frontRotation) || Input.GetKeyDown(KeyCode.RightArrow) && transform.rotation == Quaternion.Euler(frontRotation)) // 30% derecho
            {
                newTargetRotation = rightRotation;
            }
            else if (mousePosition.x > screenWidth * 0.9f && transform.rotation == Quaternion.Euler(leftRotation) || Input.GetKeyDown(KeyCode.D) && transform.rotation == Quaternion.Euler(leftRotation) || Input.GetKeyDown(KeyCode.RightArrow) && transform.rotation == Quaternion.Euler(leftRotation))
            {
                newTargetRotation = frontRotation;
            }

            // Solo cambiar si la nueva rotación es diferente
            if (newTargetRotation != targetRotation)
            {
                targetRotation = newTargetRotation;
                lastChangeTime = Time.time; // Actualizar el tiempo del último cambio
            }
        }

        if (Quaternion.Euler(targetRotation) == Quaternion.Euler(frontRotation) && Input.GetKeyDown(KeyCode.Space))
        {
            if (lights.activeSelf)
            {
                lights.SetActive(false);
            }
            else
            {
                lights.SetActive(true);
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * rotationSpeed);
    }
}
