using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, IInputListener
{
    [SerializeField] private GameObject inputListener = null;
    
    private InputController inputConfig;
    private IInputListener currentListener = null;

    private Mouse currentMouse = null;
    private Camera mainCamera = null;

    private void Awake()
    {
        mainCamera = Camera.main;
        currentMouse = Mouse.current;
        
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
        ListenAim(mainCamera.ScreenToWorldPoint(currentMouse.position.ReadValue()));
    }

    private void OnEnable() => inputConfig.Enable();
    private void OnDisable() => inputConfig.Disable();

    public void SetListener(IInputListener listener) => currentListener = listener;
    public void ShootStarted() => currentListener.ShootStarted();
    public void ShootReleased() => currentListener.ShootReleased();

    public void Roll() => currentListener.Roll();
    public void Move(Vector2 axis) => currentListener.Move(axis);

    public void ListenAim(Vector2 aimPosition) => currentListener.ListenAim(aimPosition);
}

public interface IInputListener
{
    void ShootStarted();
    void ShootReleased();
    void Roll();
    void Move(Vector2 axis);
    void ListenAim(Vector2 aimPosition);
}
