using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BookSystem : MonoBehaviour
{
    

    public static bool is_text = false;

    [SerializeField] public static bool is_Player;
    [SerializeField] public static bool is_Enemy;
    [SerializeField] public static bool is_Turntable;


    [SerializeField] public GameObject player_object;
    [SerializeField] public GameObject Enemy_object;
    [SerializeField] public GameObject Turntable_object;

    

    // Start is called before the first frame update
    void Start()
    {
        
        is_text = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    

    public void set_gameobject(bool player, bool enemy, bool turntable)
    {
        player_object.SetActive(player);
        Enemy_object.SetActive(enemy);
        Turntable_object.SetActive(turntable);

    }
    
}
