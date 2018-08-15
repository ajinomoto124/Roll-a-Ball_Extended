using System;
using UnityEngine;

[Serializable]
public class EnemyManager
{
    [HideInInspector] public GameObject m_Instance;
    [HideInInspector] public Transform m_spawnPoint;
    [HideInInspector] public Rigidbody target;
    private EnemyScript m_EScript;

    public void Setup()
    {
        m_EScript = m_Instance.GetComponent<EnemyScript>();
        m_EScript.target = target;
    }

    public void Disable()
    {
        m_EScript.enabled = false;
    }

    public void Enable()
    {
        m_EScript.enabled = true;
    }

    public void Reset()
    {
        m_Instance.transform.position = m_spawnPoint.position;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}