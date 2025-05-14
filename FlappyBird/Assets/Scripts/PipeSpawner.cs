using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipesPrefab;
    [SerializeField] private float pipeSpawnTime;
    [SerializeField] private float pipeSpawnHeightTop;
    [SerializeField] private float pipeSpawnHeightBottom;


    private void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    private IEnumerator SpawnPipe()
    {
        while (true)
        {
            Instantiate(pipesPrefab, new Vector3(3f, Random.Range(pipeSpawnHeightTop, pipeSpawnHeightBottom), 0), Quaternion.identity);

            yield return new WaitForSeconds(pipeSpawnTime);
        }
    }
}
