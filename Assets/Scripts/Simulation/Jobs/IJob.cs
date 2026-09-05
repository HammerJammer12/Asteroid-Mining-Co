public interface IJob
{
    bool IsComplete {get;}
    void Tick();
    void Cancel();
}
