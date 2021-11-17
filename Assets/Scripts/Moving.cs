using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private GameObject player;
    
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        Vector3 movement = new Vector3(deltaX, deltaY, 0);
        player.transform.position += movement;
    }
}
