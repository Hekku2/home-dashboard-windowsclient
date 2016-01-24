namespace WindowsSensorClient.Output
{
    public interface IOutput
    {
        void Print(string format, params object[] objects);
    }
}
