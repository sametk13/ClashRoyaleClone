using System;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomController : MonoBehaviour, INetworkRunnerCallbacks
{
    [SerializeField] private string _menuSceneName = String.Empty;

    WaitingMenu _waitingMenu;

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        Debug.Log($"OnDisconnectedFromServer : {runner.name}");

        // Shuts down the local NetworkRunner when the client is disconnected from the server.
        GetComponent<NetworkRunner>().Shutdown();
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log($"ShutDown : {runner.name}");

        // When the local NetworkRunner has shut down, the menu scene is loaded.
        SceneManager.LoadScene(_menuSceneName);
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log($"Joined : {player.PlayerId}");
        if (runner.LocalPlayer != player)
        {
            _waitingMenu.SetRoomNameText(runner.SessionInfo.Name);
            _waitingMenu.SetPlayerNameText(player.PlayerId.ToString(),1);
        }
    }
    public void OnSceneLoadDone(NetworkRunner runner)
    {
        if (_waitingMenu == null) _waitingMenu = FindObjectOfType<WaitingMenu>();

        int textIndex = 0;
        foreach (var player in runner.ActivePlayers)
        {
            _waitingMenu.SetRoomNameText(runner.SessionInfo.Name);
            _waitingMenu.SetPlayerNameText(player.PlayerId.ToString(),textIndex);
            textIndex++;
        }
    }
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
    }


    public void OnSceneLoadStart(NetworkRunner runner)
    {
    }
}

