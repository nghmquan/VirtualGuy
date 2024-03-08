using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Vector3 targetPoint = Vector3.zero;
    [SerializeField] private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint.x = player.transform.position.x;
        targetPoint.y = player.transform.position.y;


        if (targetPoint.y < 0)
        {
            targetPoint.y = 0;
        }

        transform.position = targetPoint;
    }
}
