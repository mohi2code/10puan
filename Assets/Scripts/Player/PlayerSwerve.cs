using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwerve : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;

    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    private void Update()
    {
        if (PlayerMovement.isMoving)
        {
            float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);
        }


    }
}