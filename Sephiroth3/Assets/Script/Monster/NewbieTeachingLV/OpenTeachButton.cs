using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTeachButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTeach()
    {
        var Teach = FindObjectOfType<TeachManager>();
        if (!Teach.isOpen)
        {
            Teach.nowNumber = 0;
            Teach.isOpen = true;
            Teach.TeachDisplay();
            Teach.ButtonDisplay();
        }
    }
}
