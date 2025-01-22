using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
   [SerializeField] float groundSpeed;

    public Transform StartPosition;
    public Transform EndPosition;

    private Vector3 movment;


    // Update is called once per frame
    void Update()
    {
        movment = new Vector3(transform.position.x, transform.position.y, transform.position.z - (groundSpeed * Time.deltaTime));

        //Si la posicion del suelo llega a la posici?n final, asignamos su posici?n a la inicial.
        if (movment.z <= EndPosition.transform.position.z)
        {
            movment = StartPosition.transform.position;
        }

        //Hacemos que la posicion sea el vector calculado.
        transform.position = movment;
    }
}
