using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, IInputListener
{
    public InputController inputConfig;
    private IInputListener currentListener = null;

    [SerializeField] private GameObject inputListener = null;

    private void Awake()
    {
        inputConfig = new InputController();

        if (inputListener != null)
        {
            currentListener = inputListener.GetComponent<IInputListener>();
        }
        
        inputConfig.MainPlayer.Shot.performed += x => ShootStarted();
        inputConfig.MainPlayer.Shot.canceled += x => ShootReleased();
        inputConfig.MainPlayer.Roll.performed += x => Roll();
    }

    private void FixedUpdate()
    {
        Move(inputConfig.MainPlayer.Movement.ReadValue<Vector2>());
    }

    private void OnEnable() => inputConfig.Enable();
    private void OnDisable() => inputConfig.Disable();

    public void SetListener(IInputListener listener) => currentListener = listener;
    public void ShootStarted() => currentListener.ShootStarted();
    public void ShootReleased() => currentListener.ShootReleased();

    public void Roll() => currentListener.Roll();
    public void Move(Vector2 axis) => currentListener.Move(axis);
    public void GetAimDirection(Vector2 direction) => Mouse.current.position.ReadValue();
}

public class FakeListener : IInputListener
{
    public void ShootStarted()
    {
        Debug.Log("Shoot");
    }

    public void ShootReleased()
    {
        throw new System.NotImplementedException();
    }

    public void Roll()
    {
        Debug.Log("Roll");
    }

    public void Move(Vector2 axis)
    {
        Debug.Log($"Move {axis}");
    }

    public void GetAimDirection(Vector2 direction)
    {
        throw new System.NotImplementedException();
    }
}

public interface IInputListener
{
    void ShootStarted();
    void ShootReleased();
    void Roll();
    void Move(Vector2 axis);
    void GetAimDirection(Vector2 direction);
}
