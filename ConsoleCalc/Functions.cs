using System;

namespace ConsoleCalc
{
    public static class Functions
    {
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
            char[] operators = {'+', '-', '*', '/',};
            foreach (var VARIABLE in operators)
            {
                if (source.ToString()[0] == VARIABLE)
                    return true;
            }
            return false;
        }
        
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