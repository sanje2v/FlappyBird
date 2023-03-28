using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartScreenScript : MonoBehaviour
{
    public GameControllerScript m_gameControllerScript;

    private UIDocument m_UIStartScreen;

    // Start is called before the first frame update
    void Start()
    {
        m_UIStartScreen = GetComponentInParent<UIDocument>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.m_UIStartScreen.enabled)
        {
            if (Input.anyKey)
            {
                this.m_UIStartScreen.enabled = false;
                this.m_gameControllerScript.IsGameStarted = true;
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
