using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Ball;

    public DefaultInput input;

    private void Start()
    {
        input = new DefaultInput();
        input.Enable();
        input.UI.Disable();
    }

    private void FixedUpdate()
    {
        if (input.Player.TurnLeft.IsPressed())
        {
            transform.Rotate(Vector3.up, Mathf.PI);
        }
        if (input.Player.TurnRight.IsPressed())
        {
            transform.Rotate(Vector3.up, -Mathf.PI);
        }

        if (Ball != null)
        {
            if (Ball.position.y < transform.position.y)
            {
                transform.position = new Vector3(0, Mathf.Lerp(Ball.position.y, transform.position.y, Time.deltaTime), 0);
            }

            Vector3 ballPosition = Ball.position;
            Vector3 forward = -transform.forward;
            Ball.position = new Vector3(forward.x, ballPosition.y, forward.z);
        }
    }
}
