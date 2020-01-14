using System.Collections.Generic;
using UnityEngine;

public class EnemiesCounter : MonoBehaviour
{
    [SerializeField] private GameObject _blackPanel;

    private HashSet<Enemy> _enemies = new HashSet<Enemy>();

    private float emptySet = 0;

    private void Start()
    {
        foreach (Enemy enemy in FindObjectsOfType<Enemy>())
        {
            enemy.OnDead += ObjectDeadHandler;
            _enemies.Add(enemy);
        }
    }

    private void ObjectDeadHandler(Enemy enemy)
    {
        _enemies.Remove(enemy);

        if (_enemies.Count == emptySet)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _blackPanel.SetActive(true);
    }
}