using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace BookShop.Web.Client.Pages;

public partial class Lifecycle
{
    [Parameter]
    public int Id { get; set; }

    private Stopwatch stopwatch = new Stopwatch();

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        stopwatch.Start();
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: SetParametersAsync - 1 called. Id: {Id}");

        await base.SetParametersAsync(parameters);

        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: SetParametersAsync - 2 called. Id: {Id}");
        await Task.Delay(100); // Simulate async work

        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: SetParametersAsync - 3 called. + 100 Id: {Id}");
    }

    override protected void OnInitialized()
    {
        base.OnInitialized();
        Console.WriteLine($"OnInitialized called. Id: {Id}");
    }

    override protected async Task OnInitializedAsync()
    {
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: OnInitializedAsync - 1 called. Id: {Id}");

        await Task.Delay(100); // Simulate async work
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: OnInitializedAsync - 2 called. + 100 Id: {Id}");

        await Task.Delay(100); // Simulate async work
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: OnInitializedAsync - 3 called. + 100 Id: {Id}");

        await Task.Delay(100); // Simulate async work
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: OnInitializedAsync - 4 called. + 100 Id: {Id}");

        await base.OnInitializedAsync();
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: OnInitializedAsync - 5 called. Id: {Id}");
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        Console.WriteLine($"OnParametersSet called. Id: {Id}");
    }

    protected override async Task OnParametersSetAsync()
    {
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: OnParametersSetAsync - 1 called. Id: {Id}");

        await Task.Delay(100); // Simulate async work
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: OnParametersSetAsync - 2 called. + 100 Id: {Id}");

        await Task.Delay(100); // Simulate async work
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: OnParametersSetAsync - 3 called. + 100 Id: {Id}");

        await base.OnParametersSetAsync();
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: OnParametersSetAsync - 4 called. Id: {Id}");
    }

    protected override bool ShouldRender()
    {
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: ShouldRender called. Id: {Id}");
        return base.ShouldRender();
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        Console.WriteLine($"OnAfterRender called. Id: {Id}");
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if( firstRender)
        {
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: OnAfterRenderAsync - 1 called. Id: {Id}, {firstRender}");

            await Task.Delay(100); // Simulate async work
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: OnAfterRenderAsync - 2 called. + 100 Id: {Id}, {firstRender}");
        }

        await base.OnAfterRenderAsync(firstRender);
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms: OnAfterRenderAsync - 3 called. Id: {Id}, {firstRender}");
    }
}