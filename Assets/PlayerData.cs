using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerData : NetworkBehaviour
{
    // Start is called before the first frame update
    [Networked]
    public string PlayerName { get; set; }
    [Networked]
    public int avatarIndex { get; set; }



}
