using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spawn : MonoBehaviour
{
    public GameObject prefabolos;
    public GameObject trackEnemy = null;
    public InputAction spawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        spawn = InputSystem.actions.FindAction("Attack");
    }
    void SpawnEnemy()
    {
        trackEnemy = Instantiate(prefabolos, gameObject.transform.position, Quaternion.identity);
    }

    void Update()
    {
        /*if (!trackEnemy || trackEnemy.transform.position.x == -10)
            SpawnEnemy();*/
        if (!trackEnemy)
            SpawnEnemy();
    }
}
