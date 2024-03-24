using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizedObject : MonoBehaviour
{
    public int indexer;
    // Start is called before the first frame update
    public List<Transform> boxPos = new List<Transform>(); 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPositions(int index,GameObject box)
    {
        print("Indexer : "+index);
        box.transform.position = boxPos[index].position;
        box.transform.eulerAngles = boxPos[index].eulerAngles;
    }
}
