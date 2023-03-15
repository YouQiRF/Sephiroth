using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Event;
using UnityEngine;

public class PointerManager : MonoBehaviour
{
    [SerializeField] public bool IsRun;

    [SerializeField] public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRun){transform.Rotate(0,0,MoveSpeed * Time.deltaTime);}
    }

    public void OnStopPointer()
    {
        EventBus.Post(new StopTruntableDetected());
    }

    public void OnResetPointer()
    {
        IsRun = true;
    }

}
