using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("數值")]
    [SerializeField] public float CauseDamage;

    
    
    [Header("物件")]
    [SerializeField] public PlayerActor _playerActor;
    [SerializeField] public PlayerFettle _playerFettle;
    [SerializeField] public TurntableManager _turntable;
    // Start is called before the first frame update
    void Start()
    {
        _playerActor = FindObjectOfType<PlayerActor>();
        _playerFettle = FindObjectOfType<PlayerFettle>();
        _turntable = FindObjectOfType<TurntableManager>();
    }



}
