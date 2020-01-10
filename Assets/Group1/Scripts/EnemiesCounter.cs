using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCounter : MonoBehaviour
{
    [SerializeField] private GameObject _blackPanel;

    private void Update()
    {
        EnemyMovement[] _enemies = FindObjectsOfType<EnemyMovement>();

        if (_enemies.Length == 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _blackPanel.SetActive(true);
    }
}