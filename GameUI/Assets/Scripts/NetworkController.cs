using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [SerializeField] private CameraMovement _playerCamera;

    private void Start()
    {
        Debug.Log("Connecting");
        PhotonNetwork.NickName = "Player" + Random.Range(0, 10000000);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the Master");
        PhotonNetwork.JoinOrCreateRoom("PrivateFMIServer", new Photon.Realtime.RoomOptions() { MaxPlayers = 10 }, null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Connected");
        _playerCamera.target = PhotonNetwork.Instantiate("PlayerRed", new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), Quaternion.identity).transform;
    }
}
