using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project;
using Project.Event;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    }

    private void Update()
    {
        
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

    public void StopGame()
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
        StopGame();
        // var nextLV = FindObjectOfType<SetActiveButton>();
        switch (LVNumber)
        {
            case 0:
                PlayerWin.OnPlayerWin();
                await Task.Delay(2500);
                SceneManager.LoadScene("TeachingB");
                break;
            case 1:
                PlayerWin.OnPlayerWin();
                await Task.Delay(2500);
                SceneManager.LoadScene("MainScenes");
                break;
            case 2:
                switch (Map_System.roomcode)
                {
                    case 0://一般
                        PlayerWin.OnPlayerWin();
                        await Task.Delay(2500);
                        Destroy(GameObject.FindWithTag("Build"));
                        map_time.is_map_time = true;
                        break;
                    case 1://休息
                        GameObject.Find("UIAnnounceText").GetComponent<Text>().text = "*按下空白鍵繼續*";
                        GameObject.Find("Turntable_UI").SetActive(false);
                        Destroy(GameObject.FindWithTag("Build"));
                        await Task.Delay(600);
                        LocationManager.instance.PlayerLocation[1]._hpData.NowHP += (LocationManager.instance.PlayerLocation[1]._hpData.MaxHP / 2);
                        LocationManager.instance.PlayerLocation[1].GetHealEffect();
                        GameObject.Find("TheSummonerA").GetComponent<FettleGeneric>()._hpData.NowHP += (GameObject.Find("TheSummonerA").GetComponent<FettleGeneric>()._hpData.MaxHP / 2);
                        GameObject.Find("TheSummonerB").GetComponent<FettleGeneric>()._hpData.NowHP += (GameObject.Find("TheSummonerA").GetComponent<FettleGeneric>()._hpData.MaxHP / 2);
                        FindObjectOfType<SpecialGameEnd>().RestEnd();
                        break;
                    case 4://菁英
                        PlayerWin.OnPlayerWin();
                        await Task.Delay(3000);
                        Destroy(GameObject.FindWithTag("Build"));
                        FindObjectOfType<SpecialGameEnd>().ChooseSummonerObj.SetActive(true);
                        break;
                    case 2://BOSS
                        PlayerWin.OnPlayerWin();
                        await Task.Delay(2500);
                        Destroy(GameObject.FindWithTag("Build"));
                        PlayerPrefs.SetInt("NeedReset",1);
                        map_time.is_map_time = true;
                        break;
                }
                break;
        }
    }

    private async void OnPlayerDead(PlayerDeadDetected obj)
    {
        PlayerPrefs.SetInt("NeedReset",1);
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
