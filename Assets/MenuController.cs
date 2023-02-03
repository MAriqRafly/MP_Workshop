using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField IF_Name;
    public TMP_InputField IF_RoomName;

    public Button Button_NextAva;
    public Button Button_PrevAva;
    public Button Button_Join;
    public GameObject PlayCam;
    public GameObject MainCam;
    [Header("Avatar")]
    public Transform Avatars;
    public int AvatarIndex = 0;
    public GameObject LobbyPanel;
    public GameObject MainMenuPanel;
    public string playerName;

    [Header("Multipalyer")]
    public GameObject Prefab_NetworkRunner;
    public NetworkRunner Runner;
    public Button Button_Start;
    public Button Button_Leave;
    public string NextRoomName;
    public TMP_Text RoomName;
    public TMP_Text TMP_PlayerList;

    void Start()
    {
        Button_NextAva.onClick.AddListener(NextAva);
        Button_PrevAva.onClick.AddListener(PrevAva);
        Button_Join.onClick.AddListener(JoinRoom);
        Button_Start.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextAva()
    {
        AvatarIndex++;
        if (AvatarIndex >= Avatars.childCount)
            AvatarIndex = 0;

        for (int i = 0; i < Avatars.childCount; i++)
        {
            if (i == AvatarIndex)
                Avatars.GetChild(i).gameObject.SetActive(true);
            else
                Avatars.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void PrevAva()
    {
        AvatarIndex--;
        if (AvatarIndex < 0)
            AvatarIndex = Avatars.childCount - 1;

        for (int i = 0; i < Avatars.childCount; i++)
        {
            if (i == AvatarIndex)
                Avatars.GetChild(i).gameObject.SetActive(true);
            else
                Avatars.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void JoinRoom()
    {
        if(Runner == null)
        {
            Runner = Instantiate(Prefab_NetworkRunner).GetComponent<NetworkRunner>();
        }
        CreateRoom();
    }

    public async void CreateRoom()
    {

        string roomName = IF_RoomName.text;
        if (roomName == "")
        {
            return;
        }

        playerName = IF_Name.text;

        var result = await Runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = roomName,
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneManager = gameObject.GetComponent<NetworkSceneManagerDefault>(),
            
        });
 

    }

    public void OpenLobby()
    {
        LobbyPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }


    Coroutine cr_updateLobby;
    public void UpdateLobby()
    {
        if (cr_updateLobby != null)
            StopCoroutine(cr_updateLobby);
        cr_updateLobby = StartCoroutine(CR_UpdateLobby());
    }

    public IEnumerator CR_UpdateLobby()
    {
        string playerList = "";

        if (Runner.IsSharedModeMasterClient)
        {
            Button_Start.gameObject.SetActive(true);
        }
        else
        {
            Button_Start.gameObject.SetActive(false);
        }


        foreach (PlayerRef player in Runner.ActivePlayers)
        {
            while(Runner.GetPlayerObject(player) == null)
            {
                yield return null;
            }
            playerList += Runner.GetPlayerObject(player).GetComponent<PlayerData>().PlayerName;
            if(player == Runner.LocalPlayer)
            {
                playerList += "(You)";
            }

            playerList += "\n";
        }
        TMP_PlayerList.text = playerList;


        yield return null;
    }

    public void StartGame()
    {
        Runner.SessionInfo.IsOpen = false;
        Runner.SetActiveScene(NextRoomName);
    }


}
