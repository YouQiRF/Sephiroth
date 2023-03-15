using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_effect : MonoBehaviour
{
    public GameObject win;
    public GameObject dead;
    public bool is_win = false, is_dead = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        end();
    }

    void end()
    {
        if (is_win)
        {
            Instantiate(win);
            is_win = false;
        }
        if (is_dead)
        {
            Instantiate(dead);
            is_dead = false;
        }
    }

    public void OnPlayerWin()
    {
        Instantiate(win);
    }

    public void OnPlayerDead()
    {
        Instantiate(dead);
    }
}
