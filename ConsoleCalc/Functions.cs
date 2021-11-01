using System;

namespace ConsoleCalc
{
    public static class Functions
    {
        //Operators array with priority, separated by a space
        public static string opsList = "^ */ +-";
        //remove Array element at index
        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if( index > 0 )
                Array.Copy(source, 0, dest, 0, index);

            if( index < source.Length - 1 )
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }
        //Check for operator
        public static bool IsOperator<T>(this T source)
        {
            string ops = opsList;
            
            while (ops.Contains(' '))
            {
                ops = ops.Remove(ops.IndexOf(' '), 1);
            }
            
            char[] operators = ops.ToCharArray();
            
            foreach (var VARIABLE in operators)
            {
                if (source.ToString()[0] == VARIABLE)
                    return true;
            }
            return false;
        }
        
        //optional methods (used only when entering values)
        public static bool ConatainOperators(this string source)
        {
            char[] chars = source.ToCharArray();
            return ConatainOperators(chars);
        }
        public static bool ConatainOperators<T>(this T[] source)
        {
            foreach (var VARIABLE in source)
            {
                if (VARIABLE.IsOperator()) 
                    return true;
            }
            return false;
        }
        public static string WaitForEqualsSign(string firstEnter)
        {
            string enter = firstEnter;
            string enterCache = enter;
            
            do
            {
                enterCache = Console.ReadLine();
                enter += enterCache;
            } while (!enterCache.Contains('='));
            
            
            return enter;
        }
    }
}