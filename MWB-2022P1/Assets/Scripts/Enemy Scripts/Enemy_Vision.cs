using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Vision : MonoBehaviour
{

    public GameObject eyes;

    public LayerMask playerLayer;

    public bool canSee;
    public float viewDistance = 10f;

    public bool playerSeen;

    public Vector3 targetSeenPosition;
    public Vector3 targetLastSeenPosition;

    public GameObject canSeeVisual;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canSeeVisual.SetActive(canSee);
        if (canSee)
        {
            RaycastHit hit;
            if (Physics.Raycast(eyes.transform.position, transform.forward, out hit, viewDistance, playerLayer))
            {
                if (hit.collider.gameObject.TryGetComponent(out Player player))
                {
                    targetSeenPosition = player.transform.position;
                    playerSeen = true;

                }
                else
                {
                    targetLastSeenPosition = targetSeenPosition;
                    //targetSeenPosition = Vector3.zero;
                    playerSeen = false;
                }
            }
            else
            {
                targetLastSeenPosition = targetSeenPosition;
                //targetSeenPosition = Vector3.zero;
                playerSeen = false;
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        Debug.DrawLine(eyes.transform.position, eyes.transform.position + (eyes.transform.forward * viewDistance), Color.red);
    }
}
