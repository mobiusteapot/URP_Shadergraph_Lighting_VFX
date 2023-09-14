using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMoveExample : MonoBehaviour
{
    [SerializeField] private Light moveLight;
    [SerializeField] private float moveSpeed = 0.05f;
    [SerializeField] private float directionChangeDelay = 3f;

    [SerializeField] private List<Color> colors;
    private Stack<Color> colorStack;

    private bool moveForward = false;

    private void Start() {
        StartCoroutine(timerCoroutine());
        colorStack = new Stack<Color>(colors);
    }

    // Move the light forward or backward depending on the current direction.
    private void FixedUpdate() {

        if (moveForward) {
            moveLight.transform.position += moveLight.transform.forward * moveSpeed * Time.deltaTime;
        } else {
            moveLight.transform.position -= moveLight.transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    // Flip moving forward or backwards whenever timer finishes. Then, change to random color and restart the timer.
    private IEnumerator timerCoroutine() {
        yield return new WaitForSeconds(directionChangeDelay);
        moveForward = !moveForward;
        moveLight.color = GetNewColorFromStack();
        StartCoroutine(timerCoroutine());
    }

    private Color GetNewColorFromStack() {
        if (colorStack.Count > 0) {
            return colorStack.Pop();
        } else {
            colorStack = new Stack<Color>(colors);
            return colorStack.Pop();
        }
    }
}
