using System;

public class MiniTimer
{
    public MiniTimer(float cooldown, bool startInited = false)
    {
        Finished = !startInited;
        SetTime(cooldown);
        ResetTimer();
    }

    public void SetTime(float time) => cooldown = time;
    
    private float cooldown = 0;
    private float currentTime = 0;
    
    public bool Finished { get; private set; }

    public event Action OnTimeFinished;
    public event Action OnUpdate;

    public void Update(float deltaTime)
    {
        if(Finished) return;

        currentTime -= deltaTime;
        OnUpdate?.Invoke();

        if (currentTime <= 0)
        {
            OnTimeFinished?.Invoke();
            Finished = true;
        }
    }

    public void ResetTimer()
    {
        currentTime = cooldown;
        Finished = false;
    }
}