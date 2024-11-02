namespace BlazorStateLightningTalk.Models;

public class AppStateDependencyInjection
{
    public TimeOnly Time { get; private set; } = TimeOnly.FromDateTime(DateTime.Now);

    public void UpdateTime()
    {
        Time = TimeOnly.FromDateTime(DateTime.Now);
        NotifyStateChanged();
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}