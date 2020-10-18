using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUP : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        GameControllerScript gc = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
        gc.UpLevel();
    }
}
