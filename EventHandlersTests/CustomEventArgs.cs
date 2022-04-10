namespace EventHandlersTests;

public class CustomEventArgs : EventArgs
{
   public CustomEventArgs(string payload)
   {
      Payload = payload;
   }

   public string Payload { get; }
}
