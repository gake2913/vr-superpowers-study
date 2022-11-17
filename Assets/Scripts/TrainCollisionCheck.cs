using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCollisionCheck : MonoBehaviour
{

    public LayerMask ObstacleLayer;
    public TrainCollisionCheck ReportToOther;
    public float Cooldown = 1f;
    public Animator[] Lightbars;

    private int totalHits = 0;
    private bool inCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReportCollision(Collider collision)
    {
        if (!inCooldown)
        {
            inCooldown = true;

            totalHits++;
            Debug.Log("Hit Obstacle " + collision.gameObject.name + ". Total Hits: " + totalHits);

            foreach (Animator anim in Lightbars)
            {
                anim.SetTrigger("Pulse_Red");
            }

            StartCoroutine(WaitCooldown());
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Collision");

        if ((ObstacleLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            if (ReportToOther != null) ReportToOther.ReportCollision(collision);
            else ReportCollision(collision);
        }
    }

    private IEnumerator WaitCooldown()
    {
        yield return new WaitForSeconds(Cooldown);
        inCooldown = false;
    }

}
