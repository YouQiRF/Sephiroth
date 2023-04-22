using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{

    [SerializeField] private PlayerManager _playerManager;

    [SerializeField] private GameObject ActorObj;

    [SerializeField] public GameObject[] TurntableUI;

    [SerializeField] public Image[] HpUI;
    // Start is called before the first frame update
    void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        FindTuntable();
        TurntableUI[0].SetActive(false);
        TurntableUI[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ShowActorPoints();
    }

    private void FindTuntable()
    {
        TurntableUI[0] = GameObject.Find("UITurntable_A");
        TurntableUI[1] = GameObject.Find("UITurntable_B");
    }

    private void ShowActorPoints()
    {
        if (_playerManager._playerActor.NowActorPoints == 1)
        {
            ActorObj.SetActive(true);
        }
        else
        {
            ActorObj.SetActive(false);
        }
    }

    public void ResetHPUI()
    {
        HpUI[0].fillAmount = 1f;
        HpUI[1].fillAmount = 1f;
        HpUI[2].fillAmount = 1f;
    }
}
