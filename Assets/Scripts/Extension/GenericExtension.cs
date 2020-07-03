using System.Collections.Generic;

public static class GenericExtension
{
    public static bool isEmpty<T>(this List<T> this_) => this_.ReferenceEquals(null) || this_.Count == 0;
    
    public static bool isEmpty<T>(this Stack<T> this_) => this_.ReferenceEquals(null) || this_.Count == 0;

    public static bool isEmpty<T>(this Queue<T> this_) => this_.ReferenceEquals(null) || this_.Count == 0;
}