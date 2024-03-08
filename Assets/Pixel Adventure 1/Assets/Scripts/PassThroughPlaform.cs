using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughPlaform : MonoBehaviour
{
    private Collider2D coll;
    private bool playerOnPlatform;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOnPlatform && (Input.GetAxis("Vertical")) < 0)
        {
            coll.enabled = false;
            StartCoroutine(EnableCollider());
        }
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        coll.enabled = true;
    }

    private void SetPlayerOnPlatform(Collision2D other, bool value)
    {
        var player = other.gameObject.GetComponent<PlayerMovement>();
        if (player != null)
        {
            playerOnPlatform = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, true);
    }
}
