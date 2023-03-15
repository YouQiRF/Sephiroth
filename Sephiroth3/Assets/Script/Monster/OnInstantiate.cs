using System.Collections;
using System.Collections.Generic;
using Project;
using Project.Event;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class OnInstantiate : MonoBehaviour
{
    [SerializeField] public GameObject[] MonsterBuild;
    public void OnInstantiateMonster()
    {
        int randomNumber = UnityEngine.Random.Range(0, 6);
        Instantiate(MonsterBuild[randomNumber], this.transform);
        EventBus.Post(new NewMonsterDetected());
    }
}
