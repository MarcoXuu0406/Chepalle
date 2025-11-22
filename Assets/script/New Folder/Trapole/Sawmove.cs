using UnityEngine;

public class SawMover : MonoBehaviour
{
    public Vector3 pointA;       // primo punto
    public Vector3 pointB;       // secondo punto
    public float speed = 2f;     // velocità movimento

    private Vector3 target;

    void Start()
    {
        target = pointB;  // parte verso B
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // se raggiunge la destinazione → cambia direzione
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pointA, 0.1f);
        Gizmos.DrawSphere(pointB, 0.1f);
        Gizmos.DrawLine(pointA, pointB);
    }
}
