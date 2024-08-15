using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSeeking : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float rotationSpeed = 2f;
    public float detectionRange = 10f;

    private Vector3 targetPosition;
    private Vector3 obstacleAvoidanceVector;

    
    void Start()
    {
        
        moveSpeed = 2f;
    }

    void Update()
    {
        

        if (player == null)
        {
            return;
        }

        // Рассчитываем вектор до игрока и устанавливаем его в качестве цели
        Vector3 playerDirection = player.position - transform.position;
        float distanceToPlayer = playerDirection.magnitude;

        if (distanceToPlayer < detectionRange)
        {
            targetPosition = player.position;
        }

        // Обход препятствий
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Obstacle")
            {
                Vector3 obstacleDirection = Vector3.Reflect(transform.forward, hit.normal);
                obstacleAvoidanceVector = obstacleDirection.normalized;
            }
        }

        // Поворачиваемся в сторону цели
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPosition - transform.position), rotationSpeed * Time.deltaTime);

        // Двигаемся вперед
        if (obstacleAvoidanceVector != Vector3.zero)
        {
            transform.Translate(obstacleAvoidanceVector * moveSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    
}
