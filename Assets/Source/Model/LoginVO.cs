using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginVO
{
    public string userName { get; set; }
    public string password { get; set; }
    public string did { get; set; }
    public string mofiID { get; set; }
    public string gameID { get; set; }

    public LoginVO()
    {
        userName = "";
        password = "";
        did = "";
        mofiID = "";
        gameID = "";
;    }
}

public class ActorCheckpointRecord
{
    public string checkpoint_name { get; set; }
    public float timeRemain { get; set; }
    public ActorCheckpointRecord()
    {
        checkpoint_name = "";
        timeRemain = 0.0f;
    }
}
