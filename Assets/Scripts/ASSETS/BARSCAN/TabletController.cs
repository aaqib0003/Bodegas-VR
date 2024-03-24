using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletController : MonoBehaviour
{

    [Header("Para regresar al inventario.")]
    public float returnTime = 1.0f;
    private float returnTimePriv;
    public Transform inventorySocket;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("si inicio de esta cosa lalal ");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND"))
        {
            returnTimePriv -= 1.0f * Time.deltaTime;

            if (returnTimePriv <= 0.5f)
            {
                returnTransform();
            }
        }
    }

    public void returnTransform() {
        this.gameObject.transform.position = inventorySocket.position;
        returnTimePriv = returnTime;
    }
}
