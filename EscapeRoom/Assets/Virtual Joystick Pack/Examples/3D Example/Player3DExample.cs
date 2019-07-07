using UnityEngine;

public class Player3DExample : MonoBehaviour {

    public float moveSpeed = 8f;
    public Joystick joystick;
    public CharacterController CharacterController;
    void Update () 
	{
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveVector);
            transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
            // transform
            CharacterController.Move(moveVector * Time.fixedDeltaTime);
        }

        Debug.Log("Touch Count:" + Input.touchCount );
        if(Input.touchCount > 1)
        {
            //TO_DO raycast and try to find the button/level to advance further
            Touch touch = Input.GetTouch(1);
            //RaycastHit hit
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Debug.DrawLine(this.transform.position, touchPosition, Color.red);
        }

        //for(int i = 0; i < Input.touchCount; i++)
        //{
        //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
        //    Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
        //}
        
	}
}