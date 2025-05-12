using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float pipeSpeed;

    void Update()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
    }
}
