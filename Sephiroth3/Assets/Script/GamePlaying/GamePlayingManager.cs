using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project;
using Project.Event;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GamePlayingManager : MonoBehaviour
{
    [SerializeField] private int LVNumber;
    [SerializeField] private bool isStop;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private TurntableGeneric[] _turntableGenerics;
    [SerializeField] public MonsterGeneric[] _MonsterGenerics;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.SceneManagement.SceneManager.activeSceneChanged += delegate(Scene arg0, Scene scene)
        {
            EventBus.OnChangeScenes();
        };
        
        EventLoad();
        ReLoadEventTuntable();
        OnStart();
        _MonsterGenerics = FindObjectsOfType<MonsterGeneric>();
        _playerManager = FindObjectOfType<PlayerManager>();
        if (LVNumber != 2)
        {
            StopGame();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StopGame();
        }
    }

    private void EventLoad()
    {
        EventBus.Subscribe<StopTruntableDetected>(OnStopTruntable);
        EventBus.Subscribe<NewRoundDetected>(OnNewRound);
        EventBus.Subscribe<OnEnemyActorDetected>(OnEnemyActor);
        EventBus.Subscribe<PlayerAttackDetected>(OnPlayerAttack);
        EventBus.Subscribe<PlayerOnSummonDetected>(OnPlayerSummon);
        EventBus.Subscribe<PlayerDeadDetected>(OnPlayerDead);
        EventBus.Subscribe<RoundStartDetected>(OnFightStart);
        EventBus.Subscribe<RoundOverDetected>(OnFightEnd);
        EventBus.Subscribe<NewRoundDetected>(OnMonsterInstantiate);
    }

    private void OnMonsterInstantiate(NewRoundDetected obj)
    {
        ReLoadEventMonster();
    }

    private async void OnStart()
    {
        await Task.Delay(500);
        //map_time.is_map_time = true;

    }

    private void StopGame()
    {
        var Pointer = FindObjectOfType<PointerManager>();
        var PointerShow = GameObject.Find("UIPointer").GetComponent<PointerUI>();
        if (!isStop)
        {
            _playerManager._playerActor._pointerManager.MoveSpeed = 0f;
            isStop = true;
        }
        else
        {
            _playerManager._playerActor._pointerManager.MoveSpeed = -180f;
            isStop = false;
        }
    }

    private void OnFightStart(RoundStartDetected obj)
    {
        //ReLoadEventMonster();
        var PointerRun = FindObjectOfType<PointerManager>();
        var HpUI = FindObjectOfType<GameUIManager>();
        var PointerShow = GameObject.Find("UIPointer").GetComponent<PointerUI>();
        PointerShow.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        PointerRun.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        PointerRun.IsRun = true;
        PointerShow.MoveSpeed = -180f;
        HpUI.ResetHPUI();
    }

    private async void OnFightEnd(RoundOverDetected obj)
    {
        var PlayerWin = FindObjectOfType<Ending_effect>();
        var Pointer = FindObjectOfType<PointerManager>();
        // var nextLV = FindObjectOfType<SetActiveButton>();
        var PointerShow = GameObject.Find("UIPointer").GetComponent<PointerUI>();
        Pointer.IsRun = false;
        PointerShow.MoveSpeed = 0f;
        PlayerWin.OnPlayerWin();

        switch (LVNumber)
        {
            case 0:
                Debug.Log("AAA");
                break;
            case 1:
                Debug.Log("BBB");
                break;
            case 2:
                await Task.Delay(2500);
                Destroy(GameObject.FindWithTag("Build"));
                map_time.is_map_time = true;
                break;
        }
    }

    private async void OnPlayerDead(PlayerDeadDetected obj)
    {
        var PlayerDead = FindObjectOfType<Ending_effect>();
        var Pointer = FindObjectOfType<PointerManager>();
        var PointerShow = FindObjectsOfType<PointerUI>();
        PlayerDead.OnPlayerDead();
        Pointer.IsRun = false;
        Array.ForEach(PointerShow, OnStop => OnStop.OnStopPointer());

        await Task.Delay(2300);
        SceneManager.LoadScene(0);
        map_time.is_new_game = true;
        //Debug.Log("PlayerDead!!");
    }

    private void OnPlayerSummon(PlayerOnSummonDetected obj)
    {
        ReLoadEventTuntable();
    }

    private void OnPlayerAttack(PlayerAttackDetected obj)
    {
        var PlayerDamage = FindObjectOfType<PlayerManager>();
        Array.ForEach(_MonsterGenerics, GetDamage => GetDamage.OnGitHit(PlayerDamage.CauseDamage));
    }

    private void OnEnemyActor(OnEnemyActorDetected obj)
    {
        //_playerManager._playerFettle.HpHit();
    }

    private void OnNewRound(NewRoundDetected obj)
    {
        var Pointer = FindObjectOfType<PointerManager>();
        Pointer.NowRound++;
        _playerManager._playerActor.changeState(new PlayerRound());
        _playerManager._playerActor.RemainingDefense = 3f;
        foreach (var VARIABLE in _MonsterGenerics)
        {
            VARIABLE.OnPassRound();
        }
        //Array.ForEach(_MonsterGenerics, monsters => monsters.OnPassRound());
    }
    private async void OnStopTruntable(StopTruntableDetected obj)
    {
        if (!isStop)
        {
            var turntable = FindObjectOfType<TurntableManager>();
            //Debug.Log(_turntableGenerics.Length);
            Array.ForEach(_turntableGenerics,ChoseTurntable => ChoseTurntable.OnChoseEvent());
            _playerManager._playerActor._pointerManager.MoveSpeed = 0f;
            turntable.ChangeAngle();
            await Task.Delay(800);
            _playerManager._playerActor._pointerManager.MoveSpeed = -180f;
        }
    }

    public void ReLoadEventTuntable()
    {
        //_turntableGenerics = new TurntableGeneric[0];
        _turntableGenerics = FindObjectsOfType<TurntableGeneric>();
    }

    public void ReLoadEventMonster()
    {
        _MonsterGenerics = FindObjectsOfType<MonsterGeneric>();
        //Debug.Log("FindMonster");
    }


}
