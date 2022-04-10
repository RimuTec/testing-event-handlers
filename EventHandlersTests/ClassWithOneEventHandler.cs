namespace EventHandlersTests;

public class ClassWithOneEventHandler
{
   public ClassWithOneEventHandler()
   {
      Received += OnReceivedCallback; // register the call-back
   }

   private void OnReceivedCallback(object? sender, CustomEventArgs e)
   {
      Console.WriteLine($"CustomEventArgs = {e}");
      Trace += e.Payload;
   }

   public string Trace { get; private set; } = string.Empty;

   public event EventHandler<CustomEventArgs>? Received;
}
