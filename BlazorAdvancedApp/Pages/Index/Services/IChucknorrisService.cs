using System.Reactive.Subjects;

namespace BlazorAdvancedApp.Pages.Index.Services
{
    public interface IChucknorrisService
    {
        BehaviorSubject<bool> ReloadJoke { get; set; }
        Task<Joke> LoadJokeAsync();
    }
}