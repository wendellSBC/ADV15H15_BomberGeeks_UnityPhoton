using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

using Hastable =  ExitGames.Client.Photon.Hashtable;

public class NetworkController : MonoBehaviourPunCallbacks
{
	[SerializeField] LobbyManager lobbySystem;

	[SerializeField] byte playerRoomMax = 2;


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.LoadLevel("SceneGame");
    }

	public override void OnConnected()
	{
		Debug.Log("OnConnected");
		//base.OnConnected();
	}

	public override void OnConnectedToMaster()
	{
		Debug.Log("OnConnectedToMaster");
		lobbySystem.PanelLobbyActive();
		//base.OnConnectedToMaster();
	}

	public override void OnJoinedLobby()
	{
		Debug.Log("OnJoinedLobby");
		//base.OnJoinedLobby();
	}

	public override void OnJoinRandomFailed(short returnCode, string message)
	{
		Debug.Log("OnJoinRandomFailed");
		string roomName = "Room" + Random.Range(1000,10000);

		RoomOptions roomOptions = new RoomOptions()
		{
			IsOpen = true,
			IsVisible = true,
			MaxPlayers = playerRoomMax
		};

		PhotonNetwork.CreateRoom(roomName,roomOptions,TypedLobby.Default);
		Debug.Log(roomName);

		//base.OnJoinRandomFailed(returnCode, message);
	}

	public override void OnJoinedRoom()
	{
		Debug.Log("OnJoinedRoom");
		//base.OnJoinedRoom();
	}

	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
		Debug.Log("OnPlayerEnteredRoom");

		if (PhotonNetwork.CurrentRoom.PlayerCount == playerRoomMax)
		{
			foreach (var player in PhotonNetwork.PlayerList)
			{
				if (player.IsMasterClient)
				{
					//StarGame();
					Hashtable props = new Hashtable
					{
						{CountdownTimer.CountdownStartTime,(float)PhotonNetwork.Time}
					};

					//PhotonNetwork.CurrentRoom.SetCustomProperties(props);
				}
			}
		}

		//base.OnPlayerEnteredRoom(newPlayer);
	}

	public override void OnRoomPropertiesUpdate(Hastable propertiesThatChanged)
	{

		if (propertiesThatChanged.ContainsKey(CountdownTimer.CountdownStartTime))
		{
			lobbySystem.lobbyStartTime.gameObject.SetActive(true);
		}
		//base.OnRoomPropertiesUpdate(propertiesThatChanged);
	}

	public override void OnDisconnected(DisconnectCause cause)
	{
			   Debug.Log("OnConnectedToMaster: " + cause.ToString());
			   lobbySystem.PanelLoginActive();
	}

	public void CancelMatch()
	{
			   PhotonNetwork.Disconnect(); //print: DisconnectByClientLogic

			   lobbySystem.connectionStatusText.gameObject.SetActive(false);
	}

	public void SearchMatch()
	{
			   PhotonNetwork.NickName = lobbySystem.playerNameInputField.text;

			   lobbySystem.connectionStatusText.gameObject.SetActive(true);

			   PhotonNetwork.ConnectUsingSettings();
	}

}
