using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;

public class NetworkHelper : MonoBehaviour, INetworkRunnerCallbacks
{
    public NetworkPrefabRef Prefab_PlayerData;
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if(runner.LocalPlayer == player)
        {
            NetworkObject playerDataNO = runner.Spawn(Prefab_PlayerData , inputAuthority: runner.LocalPlayer);
            runner.SetPlayerObject(player, playerDataNO);
            playerDataNO.GetComponent<PlayerData>().PlayerName = FindObjectOfType<MenuController>().playerName;
            playerDataNO.GetComponent<PlayerData>().avatarIndex = FindObjectOfType<MenuController>().AvatarIndex;
            FindObjectOfType<MenuController>().OpenLobby();
        }
        FindObjectOfType<MenuController>().UpdateLobby();
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {

    }






    public void OnConnectedToServer(NetworkRunner runner)
    {
        
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        
    }

   

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        
    }

    // Start is called before the first frame update
   
}
