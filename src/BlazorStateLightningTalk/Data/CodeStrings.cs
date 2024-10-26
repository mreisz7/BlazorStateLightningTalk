namespace BlazorStateLightningTalk.Data;

internal static class CodeStrings
{
    internal const string ButtonRazor = """
        <button @onclick=@OnClick>
            @Label
        </button>

        @code {
            [Parameter]
            public string Label { get; set; }
        
            [Parameter]
            public EventCallback OnClick { get; set; }
        }
        """;
}