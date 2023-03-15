using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDisPlay_Player : MonoBehaviour
{
    [SerializeField] private Animator an;
    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
    }

    public void OnAttackDisPlay()
    {
        an.Play("OnAttack");
    }
}
