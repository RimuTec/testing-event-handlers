using System.Reflection;
using NUnit.Framework;

namespace EventHandlersTests;

[TestFixture]
public class ClassWithOneEventHandlerTests
{
   [Test]
   public void RaiseEvent()
   {
      // arrange
      const string payload = "Hello, world!";
      var cut = new ClassWithOneEventHandler();

      // act
      cut.RaiseEvent(nameof(cut.Received), new CustomEventArgs(payload));

      // assert
      Assert.AreEqual(payload, cut.Trace);
   }

   // Commenting in the following demonstrates compiler error csharp(0070)
   // [Test]
   // public void RaiseEvent()
   // {
   //    // arrange
   //    const string payload = "Hello, world!";
   //    var cut = new ClassWithOneEventHandler();

   //    // act
   //    cut.Received(null, new CustomEventArgs(payload));

   //    // assert
   //    Assert.AreEqual(payload, cut.Trace);
   // }
}

public static class ObjectExtensions
{
   public static void RaiseEvent<TEventArgs>(this object target, string eventName, TEventArgs eventArgs)
   {
      Type targetType = target.GetType();
      const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;
      FieldInfo? fi = targetType.GetField(eventName, bindingFlags);
      if( fi != null )
      {
         if (fi.GetValue(target) is EventHandler<TEventArgs> eventHandler)
         {
            eventHandler.Invoke(null, eventArgs);
         }
      }
   }
}
