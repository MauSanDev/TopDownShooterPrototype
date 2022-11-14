using UnityEngine;

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
        
        inputConfig.MainPlayer.Shot.performed += x => Shoot();
        inputConfig.MainPlayer.Roll.performed += x => Roll();
    }

    private void FixedUpdate()
    {
        Move(inputConfig.MainPlayer.Movement.ReadValue<Vector2>());
    }

    private void OnEnable() => inputConfig.Enable();
    private void OnDisable() => inputConfig.Disable();

    public void SetListener(IInputListener listener) => currentListener = listener;
    public void Shoot() => currentListener.Shoot();
    public void Roll() => currentListener.Roll();
    public void Move(Vector2 axis) => currentListener.Move(axis);
}

public class FakeListener : IInputListener
{
    public void Shoot()
    {
        Debug.Log("Shoot");
    }

    public void Roll()
    {
        Debug.Log("Roll");
    }

    public void Move(Vector2 axis)
    {
        Debug.Log($"Move {axis}");
    }
}

public interface IInputListener
{
    void Shoot();
    void Roll();
    void Move(Vector2 axis);
}
