using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointInfos :ServerMsg
{
    public string MsgType { get; set; }
    public string checkPointName { get; set; }
    public string name { get; set; }
    public string location { get; set; }
    public string description { get; set; }
    public float time_limit { get; set; }
    public CheckPointInfos(string _msgType) : base(_msgType)
    {
        this.MsgType = _msgType;
    }
}
