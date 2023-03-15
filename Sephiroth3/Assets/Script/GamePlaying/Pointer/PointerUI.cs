using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerUI : MonoBehaviour
{
    [SerializeField] public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,MoveSpeed * Time.deltaTime);
    }

    public void OnStopPointer()
    {
        MoveSpeed = 0f;
    }
}
