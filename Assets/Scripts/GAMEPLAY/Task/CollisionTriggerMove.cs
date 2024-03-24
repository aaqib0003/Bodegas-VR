using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTriggerMove : MonoBehaviour {

    public Transform point;
    public Transform objectToMove;

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            objectToMove.position = point.position;
        }
    }
}
