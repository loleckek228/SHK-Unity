using System.Collections.Generic;
using UnityEngine;

public class EnemiesCounter : MonoBehaviour
{
    [SerializeField] private GameObject _blackPanel;

    private HashSet<Enemy> enemies = new HashSet<Enemy>();

    private void Start()
    {
        foreach (Enemy enemy in FindObjectsOfType<Enemy>())
        {
            enemy.Died += OnEnemyDied;
            enemies.Add(enemy);
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemies.Remove(enemy);
        enemy.Died -= OnEnemyDied;

        if (enemies.Count == 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _blackPanel.SetActive(true);
    }
}