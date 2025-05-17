using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CatchThem
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> Prefabs;

        [SerializeField] private float WaitTime, TimeError;

        private bool IsSpawn = true;

        private Player Player;

        private void Start()
        {
            Player = GameObject.FindGameObjectWithTag(Player.Tag).GetComponent<Player>();
            Defeat.Instance.AddOnLose(() => { IsSpawn = false; });
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while(IsSpawn)
            {
                if(Player.Direction == PlayerDirection.Left)
                {
                    yield return null;
                }
                Instantiate(Prefabs[Random.Range(0, Prefabs.Count)], transform).transform.localPosition = Vector3.zero;
                yield return new WaitForSeconds(WaitTime + TimeError * Random.value);
            }
        }
    }
}