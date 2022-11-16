using UnityEngine;

public abstract class AbstractNPCBehaviour : MonoBehaviour
{
    protected ShooterNPC Owner { get; private set; }

    public void Setup(ShooterNPC npc)
    {
        Owner = npc;
        OnSetup();
    }

    protected abstract void OnSetup();
}
