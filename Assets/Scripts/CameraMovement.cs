using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    float ascendSpeed; //Velocidad a la que aumenta en Y
    int incrementPoint = 0; // Posicion en Array de tiempos
    bool shouldAscend;
    bool ascending;
    public bool Horizontal = false;
    [SerializeField] float ascendStart;         // Tiempo en el cual se iniciara la subida
    [SerializeField] float startingAscendSpeed; // Velocidad inicial que empieza a los 3 segundos
    [SerializeField] float ascendIncrement;     // Multiplicacion de velocidad a medida que pasa el tiempo
    [SerializeField] Transform startPoint;      // Punto en mundo que determina altura en Y donde empieza
    [SerializeField] Transform endingPoint;
    [SerializeField] float[] incrementTimes;    // Array de tiempos en los que aumenta la velocidad

    void Awake(){
        ascending = false;
        transform.position = startPoint.position;
    }

    void Update() {
        if (Time.timeSinceLevelLoad > ascendStart && ascending == false){
            ascending = true;
            ascendSpeed = startingAscendSpeed;
            shouldAscend = true;
        }
        if(Horizontal)
        {
            if (transform.position.x < endingPoint.transform.position.x && ascending == true)
            {
				transform.Translate(ascendSpeed * Time.deltaTime, 0 , 0);
            }
        }
        else
        {
            if (transform.position.y < endingPoint.transform.position.y && ascending == true)
            {
				transform.Translate(0, ascendSpeed * Time.deltaTime, 0);
            }
        }
        
        if (Time.timeSinceLevelLoad >  incrementTimes[incrementPoint] && shouldAscend == true){
           ascendSpeed = ascendSpeed * ascendIncrement;
           if (incrementPoint < incrementTimes.Length-1){
                incrementPoint++;
           }
           else{
                shouldAscend = false;
           }
        }

    }
}
