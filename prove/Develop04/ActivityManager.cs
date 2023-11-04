public class ActivityManager
{
    public bool HandleInput(string input)
    {
        switch (input)
        {
            case "1":
                var breathingActivity = new BreathingActivity();
                breathingActivity.StartActivity();
                return true;
            case "2":
                var reflectionActivity = new ReflectionActivity();
                reflectionActivity.StartActivity();
                return true;
            case "3":
                return false; 
            default:
                Console.WriteLine("Invalid option, please try again.");
                return true;
        }
    }
}
