using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHPUIDisplay : MonoBehaviour
{
    [SerializeField] private int ThisNumber;
    [SerializeField] private float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LocationManager.instance.MonsterLocation[ThisNumber] == null)
        {
            this.transform.position = Vector3.Lerp(transform.position,
                new Vector3(this.transform.position.x, 750, this.transform.position.z), 0.02f);
        }
        else
        {
            /*this.transform.position = Vector3.Lerp(transform.position,
                new Vector3(this.transform.position.x, offset, this.transform.position.z), 0.05f);*/
        }
    }
}
