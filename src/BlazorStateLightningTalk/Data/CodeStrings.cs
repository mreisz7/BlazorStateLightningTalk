namespace BlazorStateLightningTalk.Data;

internal static class CodeStrings
{
    internal const string CascadingValueRazorComponent = """
        <CascadingValue Value=@this>
            @ChildContent
        </CascadingValue>

        @code {
            [Parameter]
            public RenderFragment? ChildContent { get; set; }

            public TimeOnly Time { get; private set; } = TimeOnly.FromDateTime(DateTime.Now);

            public void UpdateTime()
            {
                Time = TimeOnly.FromDateTime(DateTime.Now);
            }
        }
        """;

    internal const string CascadingValueButtonRazorComponent = """
        <h3>@AppState.Time.ToString("hh:mm:ss.fff")</h3>
        <button @onclick=@AppState.UpdateTime>
            Update
        </button>

        @code {
            [CascadingParameter]
            public AppStateCascadingValue AppState { get; set; } = new();
        }
        """;

    internal const string CascadingValueUsage = """
        <AppStateCascadingValue>
            <Router AppAssembly="@typeof(App).Assembly">
                ...
            </Router>
        </AppStateCascadingValue>
        """;

    internal const string AppStateDependencyInjection = """
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
        """;

    internal const string DependencyInjectionButtonRazorComponent = """
        @implements IDisposable
        @inject AppStateDependencyInjection AppState

        <h3>@AppState.Time.ToString("hh:mm:ss.fff")</h3>
        <button @onclick=@AppState.UpdateTime>
            Update
        </button>

        @code {
            protected override void OnInitialized()
            {
                AppState.OnChange += StateHasChanged;
            }

            public void Dispose()
            {
                AppState.OnChange -= StateHasChanged;
            }
        }        
        """;

    internal const string DependencyInjectionUsage = """
        ...

        builder.Services.AddScoped<AppStateDependencyInjection>();
        
        ...
        """;
}