using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Const
{
    public static class Notification
    {
        #region  NPC
        public const string LOGIN_SUCCESS = "LoginSuccess";
        public const string LOGIN_FAIL = "LoginFail";
        #endregion


        #region Login CheckPoint 
        public const string SEND_ADMIN_LOGIN = "SendAdminLogin";
        public const string SEND_ACTOR_CHECK_POINT_RECORD = "SendActorCheckPointRecord";
        #endregion

        #region Local system
        public const string LOAD_UI_FORM = "LoadUIForm";
        public const string LOAD_UI_ROOT_FORM = "LoadUIRootForm";
        public const string POP_WARNING = "PopWarning";
        public const string BACK_TO_LAST_FORM = "BackToLastForm";
        public const string GO_TO_HOME_FORM = "GoToHomeForm";
        public const string GAME_STARTED = "GameStarted";
        public const string LOAD_SCENE = "LoadScene";
        public const string SWITCH_MODE = "SwitchMode";
        #endregion

        #region Communication
        
        public const string WS_SEND = "WsSend";

        public const string GET_ACTOR_INFO = "GetActorInfo";
        public const string SHOW_ACTOR_INFO = "ShowActorInfo";
        public const string GAME_CLOSED = "GAME_CLOSED";

        public const string FINISH_CHECK_POINT_INFO = "FinishedCheckPointInfo";
        public const string NEXT_CHECK_POINT_INFO = "NextCheckPointInfo";


        public const string CONNECT_TO_WS_SERVER = "ConnectToWsServer";
        public const string SETUP_CONNECTION_WITH_SERVER = "SetupConnectionWithServer";
        #endregion
        
    }
}
