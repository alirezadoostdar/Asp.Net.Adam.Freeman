﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Tests;

public class Comparer
{
    public static Comparer<U?> Get<U>(Func<U?, U?, bool> func)
    {
        return new Comparer<U?>(func);
    }
}

public class Comparer<T> : Comparer, IEqualityComparer<T>
{
    private Func<T?, T?, bool> comparisonFunction;

    public Comparer(Func<T?, T?, bool> Func)
    {
        comparisonFunction = Func;
    }

    public bool Equals(T? x, T? y)
    {
        return comparisonFunction(x, y);
    }

    public int GetHashCode(T? obj)
    {
        return obj?.GetHashCode() ?? 0;
    }
}
