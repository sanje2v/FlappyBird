using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EndScreenScript : MonoBehaviour
{
    public GameControllerScript m_gameControllerScript;

    private UIDocument m_UIEndScreen;

    // Start is called before the first frame update
    void Start()
    {
        this.m_UIEndScreen = this.GetComponentInParent<UIDocument>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.m_UIEndScreen.enabled)
        {
            if (Input.anyKey)
            {
                this.m_gameControllerScript.RestartGame();
            }
        }
    }
}
