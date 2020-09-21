using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Const
{
    public static class Url
    {
        public const string GAME_SERVER_ADDRESS = "http://testgame.fraxinusmothership.cn"; //"http://152.136.99.117";

        public const string USER_SERVER_ADDRESS = "http://testuser.fraxinusmothership.cn";

        public const string WEB_SOCKET_HOST_URI = "http://testgame.fraxinusmothership.cn";
        public const string WEB_SOCKET_SERVER_ADDRESS = "ws://testgame.fraxinusmothership.cn/ws/actor/";  //Actor

        public const string GET_WS_TOKEN = GAME_SERVER_ADDRESS + "/game_auth/get_ws_token/";

        #region NPC
        public const string CONTROL_CENTER_LOGIN = GAME_SERVER_ADDRESS + "/actor/login/";
        public const string UPDATE_ACTOR_CHECK_POINT_RECORD = GAME_SERVER_ADDRESS + "/update_actor_checkpoint_record/";
        #endregion


    }
}
