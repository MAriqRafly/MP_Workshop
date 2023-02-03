using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class GameManager : NetworkBehaviour
{
    // Start is called before the first frame update
    public NetworkPrefabRef Prefab_Player;
    public override void Spawned()
    {
        base.Spawned();
        Runner.AddSimulationBehaviour(Object.GetComponent<GameManager>(), Object);
        SpawnChar();
    }

    public void SpawnChar()
    {
        Runner.Spawn(Prefab_Player,inputAuthority: Runner.LocalPlayer);
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
