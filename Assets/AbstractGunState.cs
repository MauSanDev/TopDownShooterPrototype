
public abstract class AbstractGunState
{
    protected Gun Gun { get; private set; }

    public abstract void Update(float deltaTime);
    protected abstract void RefreshState();
    
    public void Setup(Gun gun)
    {
        Gun = gun;
        RefreshState();
    }
    
    public abstract void Shot();
}