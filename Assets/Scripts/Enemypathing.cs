﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemypathing : MonoBehaviour {

    
    [SerializeField] WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    // Use this for initialization
    void Start () {
        waypoints = waveConfig.GetWayoints();
        transform.position = waypoints[waypointIndex].transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move() {
	    if (waypointIndex <= waypoints.Count -1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
