using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
   InputAction moveAction;
   [SerializeField] float speed = 5f;
   [SerializeField] float leftBoundPadding;
   [SerializeField] float rightBoundPadding;
   [SerializeField] float upBoundPadding;
   [SerializeField] float downBoundPadding;

   Vector3 moveVector;
   Vector2 minBounds;
   Vector2 maxBounds;

    void Start()
    {
        moveAction=InputSystem.actions.FindAction("Move");
        InitBounds();
       
    }

   
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position+moveVector*speed* Time.deltaTime;
        
        
        newPos.x = math.clamp(newPos.x, minBounds.x + leftBoundPadding,maxBounds.x - rightBoundPadding);
        newPos.y = math.clamp(newPos.y, minBounds.y + downBoundPadding,maxBounds.y - upBoundPadding);
        transform.position = newPos;
    }
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }
}
