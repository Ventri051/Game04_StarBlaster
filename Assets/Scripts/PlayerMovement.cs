using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
   InputAction moveAction;
   [SerializeField] float speed = 5f;

   Vector3 moveVector;

    void Start()
    {
        moveAction=InputSystem.actions.FindAction("Move");
    }

   
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        transform.position += moveVector*speed*Time.deltaTime;
    }
}
