using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileLaunch : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform launchPoint;


    [SerializeField] private float shootTime; // enfriamiento entre proyectiles
    [SerializeField] private float shootCounter; // temporizador de enfriamiento


    void Start()
    {
        shootCounter = shootTime;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && shootCounter <= 0)
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            // Instantiate = spawn. Toma tres valores:
            // 1. Qu� vas a instanciar - 2. D�nde lo vas a isntanciar - 3. Qu� rotaci�n va a tener el objeto
            // Quaternion: una forma de representar la rotaci�n en un espacio 3D. Si se acompa�a de .identity significa que el objeto mantendr� su rotaci�n original.
            shootCounter = shootTime;
        }


        shootCounter -= Time.deltaTime; // Hace que el enfriamiento cuente hacia abajo
    }
}

