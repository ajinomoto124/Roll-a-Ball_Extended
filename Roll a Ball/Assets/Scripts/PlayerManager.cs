using System;
using UnityEngine;

[Serializable]
public class PlayerManager
{
    [HideInInspector] public Transform m_spawnPoint;
    [HideInInspector] public GameObject m_Instance;
    private PlayerMovement m_Movement;
    //private GameObject m_canvasGameObject;

    public void Setup()
    {
        m_Movement = m_Instance.GetComponent<PlayerMovement>();
    }

    public void Disable()
    {
        m_Movement.enabled = false;
        //m_canvasGameObject.SetActive(false);
    }

    public void EnableControl()
    {
        m_Movement.enabled = true;
        //m_canvasGameObject.SetActive(true);
    }

    public void Reset()
    {
        m_Instance.transform.position = m_spawnPoint.position;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}
