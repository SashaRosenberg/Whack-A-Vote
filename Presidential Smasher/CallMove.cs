using UnityEngine;
using System.Collections;

public class CallMove : MonoBehaviour {

void OnTriggerEnter (Collider col)
    {

        if ((col.GetComponent("Mover") as Mover) != null)
        {
            Debug.Log("inside");
            Mover move;
            move = col.GetComponent<Mover>();
            move.moveback();
        }
    }
}
