using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class CheckPointView : UIViewBase
{
    public event Action GetActorInfo = delegate { };
    public ActorCheckpointRecord actorcheckPointRecord { get; private set; }

    [SerializeField]
    private Image m_actorIcon;
    [SerializeField]
    private Text m_actorName;
    [SerializeField]
    private Text m_eidText;
    [SerializeField]
    private Text m_character;

    [SerializeField]
    private Text m_groupName;
    [SerializeField]
    private Text m_location;
    [SerializeField]
    private Text m_description;
    [SerializeField]
    private Image m_finishedImage;
    [SerializeField]
    private Image m_fillImage;
    [SerializeField]
    private Text m_timeText;

    private float timeContainer = 1.0f;
    private float limitTime = 0.0f;
    public float timeRemain = 5.0f;
    private Color orangeColor = new Color(239, 163, 20);
    public bool isWSFirstSend = false;

    [SerializeField]
    private AudioClip m_finishCheckPointClip;
    [SerializeField]
    private AudioClip m_countDownCheckPointClip;
    [SerializeField]
    private AudioClip m_closeToCheckPointClip;
    [SerializeField]
    private AudioClip m_overTimeCheckPointClip;
    private void Start()
    {
        AppFacade.instance.RegisterMediator(new CheckPointViewMediator(this));
        GetActorInfo();
    }
    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(CheckPointViewMediator.NAME);
        StopAllCoroutines();
    }
    public void ActorInfoInit(ActorInfo _actorInfo)
    {
        m_actorName.text = _actorInfo.caster;
        m_eidText.text = _actorInfo.eid;
        m_character.text = _actorInfo.character;
        Addressables.LoadAssetAsync<Sprite>(_actorInfo.image).Completed += OnImageInstantiated;
    }
    private void OnImageInstantiated(AsyncOperationHandle<Sprite> _obj)
    {
        m_actorIcon.sprite = _obj.Result;
    }
    public void UpdateUnFinishedCheckPointInfo(CheckPointInfos checkPointInfos)
    {
        actorcheckPointRecord.checkpoint_name = checkPointInfos.checkPointName;
        m_groupName.text = checkPointInfos.name;
        m_location.text = checkPointInfos.location;
        m_description.text = checkPointInfos.description;
        m_finishedImage.gameObject.SetActive(false);
        m_timeText.gameObject.SetActive(true);
        limitTime = checkPointInfos.time_limit;
        timeContainer = checkPointInfos.time_limit;

        StartCoroutine("CountDown");
    }
    IEnumerator CountDown()
    {
        if (limitTime>timeRemain)
        {
            m_finishedImage.color = Color.blue;
            yield return new WaitForSeconds(1.0f);
            limitTime--;
            AudioSource.PlayClipAtPoint(m_countDownCheckPointClip, Vector3.zero);
            m_fillImage.fillAmount = 1 - (limitTime / timeContainer);
            m_timeText.text = limitTime.ToString();
            actorcheckPointRecord.timeRemain = limitTime;
        }
        else if (0 <limitTime && limitTime <= timeRemain)
        {
            m_finishedImage.color = orangeColor;
            yield return new WaitForSeconds(1.0f);
            limitTime--;
            AudioSource.PlayClipAtPoint(m_closeToCheckPointClip, Vector3.zero);
            m_fillImage.fillAmount = 1 - (limitTime / timeContainer);
            m_timeText.text = limitTime.ToString();
            actorcheckPointRecord.timeRemain = limitTime;
        }
        else if (limitTime==0)
        {
            yield return new WaitForSeconds(1.0f);
            limitTime++;
            m_fillImage.fillAmount = 0.0f;
            AudioSource.PlayClipAtPoint(m_overTimeCheckPointClip, Vector3.zero);
            m_timeText.text = limitTime.ToString();
            actorcheckPointRecord.timeRemain = -limitTime;
        }
    }
    public void UpdateFinishedCheckPointInfo(CheckPointInfos checkPointInfos)
    {
        actorcheckPointRecord.checkpoint_name = checkPointInfos.checkPointName;
        actorcheckPointRecord.timeRemain = 0.0f;

        AudioSource.PlayClipAtPoint(m_finishCheckPointClip, Vector3.zero);
        m_groupName.text = checkPointInfos.name;
        m_location.text = checkPointInfos.location;
        m_description.text = checkPointInfos.description;

        m_finishedImage.gameObject.SetActive(true);
        m_finishedImage.color = Color.green;
        m_timeText.gameObject.SetActive(false);
    }
    public void CloseCoroutin()
    {
        StopCoroutine("CountDown");
    }
}
