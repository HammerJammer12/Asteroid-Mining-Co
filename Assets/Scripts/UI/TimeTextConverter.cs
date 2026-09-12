using System.Collections.Generic;

public static class TimeTextConverter 
{
    public static string HoursToText(int hours)
    {
        int years = hours / (24 * 365);
        int remainingHours = hours % (24 * 365);
        
        int months = remainingHours / (24 * 30);
        remainingHours %= (24 * 30);
        
        int weeks = remainingHours / (24 * 7);
        remainingHours %= (24 * 7);
        
        int days = remainingHours / 24;
        int finalHours = remainingHours % 24;
        
        var parts = new List<string>();
        
        if (years > 0) parts.Add($"{years} years");
        if (months > 0) parts.Add($"{months} months");
        if (weeks > 0) parts.Add($"{weeks} weeks");
        if (days > 0) parts.Add($"{days} days");
        parts.Add($"{finalHours} hours");
        
        return string.Join(" ", parts);
    }
}
