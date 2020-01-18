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
            enemy.OnDead += OnEnemyDead;
            enemies.Add(enemy);
        }
    }

    private void OnEnemyDead(Enemy enemy)
    {
        enemies.Remove(enemy);
        enemy.OnDead -= OnEnemyDead;

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