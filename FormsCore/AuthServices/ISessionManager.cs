public interface ISessionManager
{
    void DoCheck(int sessionTimeout);
    SessionContext GetById(string id);
    bool ContainsKey(string id);
    void Invalidate(string cookies);
}