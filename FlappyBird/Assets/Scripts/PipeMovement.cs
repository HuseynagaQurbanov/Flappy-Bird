using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] private float pipeSpeed;


    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
    }
}
