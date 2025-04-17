# ResultOf (Result.Simplified on nuget.org)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

<!--
[![Build Status](https://dev.azure.com/adamkarlsson/Result.Simplified/_apis/build/status/adamkarlsson.Result.Simplified?branchName=master)](https://dev.azure.com/adamkarlsson/Result.Simplified/_build/latest?definitionId=1&branchName=master)
[![Code Coverage](https://codecov.io/gh/adamkarlsson/Result.Simplified/branch/master/graph/badge.svg)](https://codecov.io/gh/adamkarlsson/Result.Simplified)
-->
[![NuGet](https://img.shields.io/nuget/v/Result.Simplified.svg)](https://www.nuget.org/packages/Result.Simplified)
[![NuGet](https://img.shields.io/nuget/dt/Result.Simplified.svg)](https://www.nuget.org/packages/Result.Simplified)


**ResultOf** enables dot net methods to return an indication of success or failure, for any method return type (including void).
It shouldn't be used instead of exceptions, but rather enable a method to return a failure indication in non-exceptional circumstances.

Use `Result` to enable void methods to return an indication of success or failure, 
and `Result<T>` to enable non-void methods to do the same.

Both `Result` and `Result<T>` overloads the `&` and `|` operators as well as the `true` and `false` operators, 
meaning you can easily combine results in a short-circute manner for easy validations.  


### Usage example:

**Return a *`Result`* from a method:**
```csharp
Result DoSomething()
{
    // some code...
    return condition
        ? Result.Success()
        : Result.Fail("Something went wrong...");
}
```

**Return a *`Result<T>`* from a method:**
```csharp
Result<int> DoSomethingAndReturnAnInt()
{
    // some code...
    return condition
        ? Result<int>.Success(5)
        : Result<int>.Fail("Something went wrong...");
}
```

**Consume a method that returns a *`Result`***
```csharp
void DoIfMethodSucceeded()
{
    var result = DoSomething();
    if(!result.IsSuccess)
    {   
        // Something went wrong, do something with result.ErrorDescription 
        // log or show the user or whatever
        return;
    }
        // Everything is fine, you can go on with your code
    }
```

**Consume a method that returns a *`Result<T>`***
```csharp
bool DoIfMethodSucceeded()
{
    var result = DoSomethingAndReturnAnInt();
    if(!result.IsSuccess)
    {   
        // Something went wrong, do something with result.ErrorDescription 
        // log or show the user or whateverlog or show the user or whatever
        return false;
    }
        var intValue = result.Value;
        // Everything is fine, you can go on with your code
    }
```

**Note:** Since `Result` and `Result<T>` overloads the `true` and `false` operators,
you don't techinally have to use the `IsSeuccess` property to check if the result is a success or not,
but I do recommend it for readability.

```csharp
void DoIfMethodSucceeded()
{
    var result = DoSomething();
    if(!result)
    {   
        // Something went wrong, do something with result.ErrorDescription 
        // log or show the user or whatever
        return;
    }
        // Everything is fine, you can go on with your code
    }
```

Since `Result` and `Result<T>` overloads the `&` and `|` operators as well,
you can combine multiple results in a short-circuit manner.

```csharp
Result FailFast()
{
    var result = DoSomething() // returns a result instance
        && DoSomethingElse() // returns nother result instance
        && DoAnotherThing() // returns nother result instance;

    // result is the first failed result, or the last one if all succeeded.

    return result;
}

Result FailSlow()
{

    var result = DoSomething() // returns a result instance
        || DoSomethingElse() // returns nother result instance
        || DoAnotherThing() // returns nother result instance;
    
    // result is the last failed result, or the first one if all succeeded.

    return result;    
}
```


**And a validation usage example:**
```csharp
Result<SomeObject> Validate(SomeObject someObject)
{
    
    return Validate("someObject is null.", d => d is object) 
        && Validate("someObject has no SomeProperty.", d => d.SomeProperty is object) 
        && Validate("SomeProperty is invalid.", d => d.SomeProperty.IsValid) 
        && Validate("SomeCollection is empty.", d => (d.SomeCollection?.Count ?? 0) > 0);

    Result<SomeObject> Validate(string errorMessage, Predicate<SomeObject> predicate)
    {
        var isValid = predicate(someObject);
        if (!isValid)
        {
            // Log non-exceptional error here...
        }
        return isValid 
            ? Result<SomeObject>.Success(rbMatch) 
            : Result<SomeObject>.Fail(errorMessage);
    }
}
```
