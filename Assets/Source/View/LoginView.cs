using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoginView : UIViewBase
{
    public event Action TryLogin = delegate { };

    public LoginVO loginVO { get; private set; }

    [SerializeField]
    private GameObject m_loginPanel;
    [SerializeField]
    private Button m_mofiIdInputBtn;
    [SerializeField]
    private Button m_loginButton;
    [SerializeField]
    private InputField m_userNameField;
    [SerializeField]
    private InputField m_passwordField;
    [SerializeField]
    private Text m_loginResultText;
    [SerializeField]
    private GameObject m_mofiIdInputPanel;
    [SerializeField]
    private InputField m_mofiIdInputField;
    [SerializeField]
    private Button m_mofiIdBackBtn;
    [SerializeField]
    private Button m_mofiIdEnterButton;
    private string m_mofiId;

    private void Start()
    {
        AppFacade.instance.RegisterMediator(new LoginViewMediator(this));
        m_loginButton.onClick.AddListener(() => {
            TryLogin();
        });
        m_mofiIdInputBtn.onClick.AddListener(() => ActivateMofiIdPanel());
        m_mofiIdBackBtn.onClick.AddListener(() => ActivateLoginPanel());
        m_mofiIdEnterButton.onClick.AddListener(() => SaveMofiId());
        m_mofiIdInputField.onValueChanged.AddListener(SetMofiId);
        m_userNameField.onValueChanged.AddListener((string _userName) => { loginVO.userName = _userName; });
        m_passwordField.onValueChanged.AddListener((string _password) => { loginVO.password = _password; });
        loginVO = new LoginVO();
    }
    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(LoginViewMediator.NAME);
    }
    private void ActivateMofiIdPanel()
    {
        if (m_mofiIdInputPanel.activeSelf == false)
        {
            m_loginPanel.SetActive(false);
            m_mofiIdInputPanel.SetActive(true);
            m_mofiIdInputField.text = PlayerPrefs.GetString("MofiID");
        }
    }
    public void ActivateLoginPanel()
    {
        m_loginPanel.SetActive(true);
        m_mofiIdInputPanel.SetActive(false);
    }
    private void SetMofiId(string _mofiId)
    {
        m_mofiId = _mofiId;
        loginVO.mofiID = m_mofiId;
    }
    private void SaveMofiId()
    {
        if (m_mofiId !=null)
        {
            PlayerPrefs.SetString("MofiID", m_mofiId);
            Debug.Log("MofiID=" + loginVO.mofiID);
        }
    }
    public void SetLoginResultText(string _result)
    {
        m_loginResultText.text = _result;
    }
    private void ClearUI()
    {
        m_userNameField.text = "";
        m_passwordField.text = "";
        m_loginResultText.text = "";
    }
}
