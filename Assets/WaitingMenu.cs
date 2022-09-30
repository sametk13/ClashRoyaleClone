using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitingMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI roomName;
    [SerializeField] List<TextMeshProUGUI> playerNameText = new List<TextMeshProUGUI>();

    public void SetRoomNameText(string _roomName)
    {
        roomName.SetText(_roomName);
    }

    public void SetPlayerNameText(string _playerName,int _textIndex)
    {
        playerNameText[_textIndex].SetText(_playerName);
    }

}
