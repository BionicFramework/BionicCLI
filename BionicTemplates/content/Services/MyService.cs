using BionicExtensions.Attributes;

[Injectable(typeof(IMyService))]
public class MyService : IMyService
{
  // Implement your service here
}