using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Event;
using UnityEngine;

public class TurntTest : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            var Pointer = FindObjectOfType<PointerManager>();
            if (Pointer.IsRun){Pointer.OnStopPointer();}
            else{Pointer.OnResetPointer();}
        }
    }
}
