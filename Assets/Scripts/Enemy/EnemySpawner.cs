using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IStart
{
    [SerializeField] private ObjectPool _op;
    [SerializeField] private GameObject PointA;
    [SerializeField] private GameObject PointB; //between these to points enemies will spawn 
    private int _spawnPointsAmount =5;
    [SerializeField] private float _timeBetweenSpawns = 1f;
    [SerializeField] private float[] _spawnPoints;
    public List<int> listNumbers;

    public void GameStart()
    {
        _spawnPoints = new float[_spawnPointsAmount];
        FindSpawnPoints(_spawnPointsAmount);
        StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawn()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_timeBetweenSpawns);
        }
    }
    private void FindSpawnPoints(int amount)
    {
        float pA = PointA.transform.position.y;
        float pB = PointB.transform.position.y;

        float odd = Mathf.Abs((pA - pB) / (amount + 1));
        if (pA > pB)
        {
            for (int i = 0;i <_spawnPoints.Length ;i++)
            {
                _spawnPoints[i] = pB + odd * (i + 1);
            }
        }
    }
    private void Spawn()
    {
        int loopRepeats = Random.Range(1, _spawnPointsAmount );

        listNumbers = new List<int>();
        int number;
        for (int i = 0; i <= loopRepeats; i++)
        {
            do
            {
                number = Random.Range(0, _spawnPointsAmount);
            } while (listNumbers.Contains(number));
            listNumbers.Add(number);
            //Debug.Log(number);
        }
        for (int i = 0;i <= loopRepeats; i++)
        {
            Debug.Log(listNumbers);
            _op.SpawnFromPool("Enemy", new Vector3(PointA.transform.parent.transform.position.x , _spawnPoints[listNumbers[i]], PointA.transform.parent.transform.position.z), Quaternion.identity);
        }
        listNumbers.Clear();
    }
}