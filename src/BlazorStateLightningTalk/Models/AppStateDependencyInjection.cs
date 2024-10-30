namespace BlazorStateLightningTalk.Models;

public class AppStateDependencyInjection
{
    public DateTime Date { get; private set; } = DateTime.Now;

    public void UpdateDate()
    {
        Date = DateTime.Now;
        NotifyStateChanged();
    }

    public event Action? OnChange;

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}