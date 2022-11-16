using UnityEngine;
public class NPCDeathState : AbstractNPCState
{
    public NPCDeathState(ShooterNPC owner) : base(owner) { }
    
    public override void OnStateApply()
    {
        Owner.SetColor(Color.gray);
        Owner.GunRotator.gameObject.SetActive(false);
        Owner.SetTouchable(false);
    }
    
    public override void ShootStarted() { }
    public override void ShootReleased() { }
    public override void Roll() { }
    public override void Reload() { }
    public override void Move(Vector2 axis) { }
    public override void ListenAim(Vector2 aimPosition) { }
}