using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRoad : MonoBehaviour
{
    public Transform startPoint; // Posición inicial
    public Transform endPoint; // Posición final
    public float maxSpeed = 40f; // Velocidad máxima
    [Range(0,1)]
    public float accelerationPoint = 0.75f; // Punto del recorrido (75%) donde alcanza la velocidad máxima

    private float currentSpeed = 0.25f; // Velocidad actual
    private Vector3 direction; // Dirección del movimiento
    private float totalDistance; // Distancia total del recorrido
    [SerializeField]lightConfig lConfig;
    [SerializeField] GameManager gm;

    void Start()
    {
        // Configura la posición inicial del objeto y calcula la dirección
        gm = FindAnyObjectByType<GameManager>();
        lConfig = FindAnyObjectByType<lightConfig>();
        transform.position = startPoint.position;
        direction = (endPoint.position - startPoint.position).normalized;

        // Calcula la distancia total entre el inicio y el final
        totalDistance = Vector3.Distance(startPoint.position, endPoint.position);
    }

    void Update()
    {
        // Calcula la distancia recorrida desde el punto inicial
        float distanceTraveled = Vector3.Distance(startPoint.position, transform.position);

        // Calcula el porcentaje del recorrido completado
        float progress = distanceTraveled / totalDistance;

        // Calcula la velocidad según el progreso
        if (progress <= accelerationPoint)
        {
            // Aumenta la velocidad proporcionalmente al progreso (0% a 75%)
            currentSpeed = Mathf.Lerp(0.2f, maxSpeed, progress / accelerationPoint);
        }
        else
        {
            // Mantén la velocidad máxima para el 25% restante
            currentSpeed = maxSpeed;
        }

        // Detén el movimiento si ha llegado al destino
        if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
        {
            transform.position = endPoint.position; // Ajusta la posición final
            currentSpeed = 0;
            if (lConfig.Lose())
            {
                gm.YouLoseRoad();
            }
            else
            {
                Debug.Log("No has muelto");
                gameObject.SetActive(false);
                transform.position = startPoint.position;
            }
        }

        // Mueve el objeto en la dirección hacia el punto final
        transform.position += direction * currentSpeed * Time.deltaTime;
    }

}
