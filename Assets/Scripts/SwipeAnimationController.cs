using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeAnimationController : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component
    private const float SWIPE_THRESHOLD = 50f; // Minimum distance to register a swipe
    private const float SWIPE_ANGLE_TOLERANCE = 30f; // Tolerance for swipe direction

    void Start()
    {
        // Get Animator component attached to the GameObject
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is missing. Please attach an Animator to the GameObject.");
        }
    }

    void Update()
    {
        HandleSwipe();
    }

    private void HandleSwipe()
    {
        if (SwipeInputManager.Instance.DetectSwipe(out Vector2 swipeDelta))
        {
            float swipeMagnitude = swipeDelta.magnitude;
            float swipeAngle = Vector2.Angle(Vector2.up, swipeDelta);

            // Check for diagonal swipe in the direction (approximately)
            if (swipeMagnitude > SWIPE_THRESHOLD && swipeDelta.x > 0 && swipeDelta.y > 0 && swipeAngle > 45 - SWIPE_ANGLE_TOLERANCE && swipeAngle < 45 + SWIPE_ANGLE_TOLERANCE)
            {
                PlayAnimation("Left Stomach");
            }
        }
    }

    private void PlayAnimation(string animationName)
    {
        if (animator != null)
        {
            animator.Play(animationName);
        }
    }
}
