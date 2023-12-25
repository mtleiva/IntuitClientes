public interface ILoggingManager : IUnityContainerService
{
    string Name { get; set; }

    void Debug(string message);

    void Info(string message);

    void Warn(string message);

    void Error(string message);

    void Error(string message, Exception ex);

    void Fatal(string message);

    void Trace(string message);

    void Trace(string message, Exception ex);
}


public interface IUnityContainerService
{
}