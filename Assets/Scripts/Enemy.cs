using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody rb;
    private GameObject player;
    private bool isStunned = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (isStunned || player == null) return;

        Vector3 dir = player.transform.position - transform.position;
        rb.AddForce(dir * speed);
        dir.Normalize();
        rb.AddForce(dir * speed);
    }

    public void StunEnemy(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(StunRoutine(duration));
    }

    private IEnumerator StunRoutine(float duration)
    {
        isStunned = true;

        // ?????????????
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        yield return new WaitForSeconds(duration);

        isStunned = false;
    }
}
