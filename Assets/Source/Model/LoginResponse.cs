using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginResponse : HttpResponse
{
    public ActorInfo actor_info { get; set; }
    public LoginResponse(int _errCode, string _errMsg) : base(_errCode, _errMsg)
    {
        this.err_code = _errCode;
        this.err_msg = _errMsg;
    }
}
public class ActorInfo
{
    public string eid { get; set; }
    public string character { get; set; }
    public string caster { get; set; }
    public string image { get; set; }
    public int rank { get; set; }
}
