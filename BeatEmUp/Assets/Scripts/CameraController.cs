using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float verticalOffset;
    [SerializeField]
    private float lookAheadDistanceX;
    [SerializeField]
    private float lookSmoothTimeX;
    [SerializeField]
    private float verticalSmoothTime;
    [SerializeField]
    private Vector2 focusAreaSize;
    private float currentLookAheadX;
    private float targetLookAheadX;
    private float lookAheadDirectionX;
    private float smoothLookVelocityX;
    private float smoothLookVelocityY;
    private bool lookAheadStop;
    private PlayerController controller;
    private FocusArea focusArea;

   

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        focusArea = new FocusArea(controller.playerBound.bounds, focusAreaSize);

    }
     void LateUpdate()
    {
        focusArea.Update(controller.playerBound.bounds);
        Vector2 focusPosition = focusArea.center + Vector2.up * verticalOffset;
        if(focusArea.velocity.x != 0.0f)
        {
            lookAheadDirectionX = Mathf.Sin(focusArea.velocity.x);
            if (Mathf.Sin(controller.velocity.x) == Mathf.Sin(focusArea.velocity.x) && controller.velocity.x != 0.0f)
            {
                lookAheadStop = false;
                targetLookAheadX = lookAheadDirectionX * lookAheadDistanceX;

            }
            else
            {
                if (!lookAheadStop)
                {
                    lookAheadStop = true;
                }
                targetLookAheadX = currentLookAheadX + (lookAheadDistanceX * lookAheadDistanceX - currentLookAheadX) / 4.0f;
            }

        }
        currentLookAheadX = Mathf.SmoothDamp(currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookSmoothTimeX);
        focusPosition.y = Mathf.SmoothDamp(transform.position.y, focusPosition.y, ref smoothLookVelocityY, verticalSmoothTime);
        focusPosition += Vector2.right * currentLookAheadX;
        transform.position = (Vector3)focusPosition + Vector3.forward * -10.0f;
    }
    struct FocusArea
    {
        public Vector2 velocity;
        public Vector2 center;
        public float left, right, top, bottom;

        public void Update(Bounds target)
        {
            float shiftX = 0.0f;
            if(target.min.x < left)
            {
                shiftX = target.min.x - left;
            }
            else if(target.max.x > right)
            {
                shiftX = target.max.x - right;
            }
            left += shiftX;
            right += shiftX;
            float shiftY = 0.0f;
            if (target.min.y < bottom)
            {
                shiftY = target.min.y - bottom;
            }
            else if (target.max.y > top)
            {
                shiftY = target.max.y - top;
            }
            top += shiftY;
            bottom += shiftY;
            velocity = new Vector2(shiftX, shiftY);
            center = new Vector2((left + right) / 2.0f, (top + bottom) / 2.0f);

        }
        public FocusArea(Bounds targetBounds, Vector2 size)
        {
            left = targetBounds.center.x - size.x / 2.0f;
            right = targetBounds.center.x + size.x / 2.0f;
            bottom = targetBounds.min.y;
            top = targetBounds.min.y + size.y;
            velocity = Vector2.zero;
            center = new Vector2((left + right) / 2.0f, (top + bottom) / 2.0f);
        }

        
    }
}

