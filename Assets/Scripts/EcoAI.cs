using UnityEngine;

public class EcoAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int index = 0;
    public float speed = 2f;

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            patrolPoints[index].position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, patrolPoints[index].position) < 0.1f)
        {
            index = (index + 1) % patrolPoints.Length;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        IErasable i = collision.GetComponent<IErasable>();
        if (i != null)
            i.Erase();
    }
}
