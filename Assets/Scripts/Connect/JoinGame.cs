using Facebook.Unity;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinGame : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
    public GameObject IDUIContainer;
    private void Start()
    {
        StartCoroutine(JoiningRoom());
    }

    private IEnumerator JoiningRoom()
    {
        var count = 0;
        var limit = 10 * 60;
        while (true)
        {
            if (PhotonNetwork.IsConnected)
            {
                RoomOptions opitions = new();
                opitions.MaxPlayers = 10;
                opitions.IsOpen = true;
                StatusMessage.Instance.SendStatusMessage("Game Joining");
                PhotonNetwork.JoinOrCreateRoom("Practice", opitions, TypedLobby.Default);
                break;
            }
            count++;
            yield return null;
            if (count > limit)
            {
                break;
            }
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        StatusMessage.Instance.SendStatusMessage("Game Entered");

        var randomX = Random.Range(-9.0f, 9.0f);
        var randomY = Random.Range(-9.0f, 9.0f);
        var pos = new Vector3(randomX, 1.0f, randomY);

        var playerobj = PhotonNetwork.InstantiateRoomObject("Player", pos, Quaternion.identity);
        var playerui = PhotonNetwork.InstantiateRoomObject("PlayerID", Vector3.zero, Quaternion.identity);
        playerui.GetComponent<PlayerID>().SetUI(playerui, $"ID[{AccessToken.CurrentAccessToken.UserId}]");
        playerui.transform.parent = IDUIContainer.transform;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        StatusMessage.Instance.SendStatusMessage("Game JoinFailed, Trying make Room..");
    }
}
