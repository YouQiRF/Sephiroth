using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_Location : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Player_Location")]
    [SerializeField] protected GameObject[] Player_Location = new GameObject[3];
    //[SerializeField] protected GameObject[] Player_Location_pos = new GameObject[3];

    [Header("Enemy_Location")]
    [SerializeField] protected GameObject[] Enemy_Location = new GameObject[3];
    //[SerializeField] protected GameObject[] Enemy_Location_pos = new GameObject[3];
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Location_Update();
    }
    void Location_set(GameObject[] gameObjects)
    {
        if (gameObjects[0] == null)
        {
            if (gameObjects[1] != null)
            {
                
                gameObjects[0] = gameObjects[1];
                gameObjects[1] = null;
                if (gameObjects[2] != null)
                {
                    
                    gameObjects[1] = gameObjects[2];
                    gameObjects[2] = null;
                }
            }
        }

        if (gameObjects[1] == null)
        {
            if (gameObjects[2] != null)
            {
                gameObjects[1] = gameObjects[2];
                gameObjects[2] = null;
            }
        }
    }

    void Location_Update()
    {
        Location_set(Player_Location);
        Location_set(Enemy_Location);
    }
}
