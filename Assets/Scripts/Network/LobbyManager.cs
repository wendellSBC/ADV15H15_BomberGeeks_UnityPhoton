﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{

	[SerializeField] GameObject panelLogin;
	[SerializeField] GameObject panelLobby;

	public Text lobbyStartTime;
	public InputField playerNameInputField;

	public string playerName;
	public Text connectionStatusText;
	    
    void Start()
    {
        lobbyStartTime.gameObject.SetActive(false);
		connectionStatusText.gameObject.SetActive(false);
    }

	public void PanelLobbyActive()
	{
		panelLobby.SetActive(true);
		panelLogin.SetActive(false);
	}

	public void PanelLoginActive()
	{
		panelLogin.SetActive(true);
		panelLobby.SetActive(false);

	}

   
    void Update()
    {
        
    }
}
