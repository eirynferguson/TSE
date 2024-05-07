using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EF_CursorLable : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;
    public Image playerView;
    bool pointAtInteract;
    public float viewUpdateshrpness = 5f;

    RectTransform viewRectTransform;
    PlayerViewData viewDataDefault;
    PlayerViewData viewDataTarget;
    PlayerViewData currentView;
    PlayerController playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
        mainCamera = playerScript.mainCamera;
    }

    // Update is called once per frame
    void Update()
    {
        updateLookAtInteract(false);
        pointAtInteract = playerScript.targetObject;
    }

    void updateLookAtInteract(bool interact)
    {
        if ((interact || !pointAtInteract) && playerScript.targetObject)
        {
            currentView = viewDataTarget;
            //CrosshairImage.sprite = m_CurrentCrosshair.CrosshairSprite;
            viewRectTransform.sizeDelta = currentView.PlayerViewSize * Vector2.one;
        }
        else if ((interact || pointAtInteract) && !playerScript.targetObject)
        {
            currentView = viewDataDefault;
            //CrosshairImage.sprite = m_CurrentCrosshair.CrosshairSprite;
            viewRectTransform.sizeDelta = currentView.PlayerViewSize * Vector2.one;
        }

        PlayerView.color = Color.Lerp(PlayerView.color, currentView.PlayerViewColor, Time.deltaTime * viewUpdateshrpness);
        viewRectTransform.sizeDelta = Mathf.Lerp(viewRectTransform.sizeDelta.x, currentView.PlayerViewSize, Time.deltaTime * viewUpdateshrpness) * Vector2.one;
    }
}
