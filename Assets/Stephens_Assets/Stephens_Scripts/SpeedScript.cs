using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameControllerScript controller = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
        controller.SpeedAdd();

    }
}
