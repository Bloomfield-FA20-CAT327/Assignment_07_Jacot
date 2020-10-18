using System.Collections;
using UnityEngine;

public class StrengthScript : MonoBehaviour
{

    
    void OnTriggerEnter(Collider other)
    {
         GameControllerScript controller = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();

        controller.StrengthAdd();
    }
}
