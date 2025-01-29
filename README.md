# [WORK IN PROGRESS] ArchGuard

`ArchGuard` is a powerful and flexible architecture validation library for .NET projects, inspired by [NetArchTest.eNhancedEdition](https://github.com/NeVeSpl/NetArchTest.eNhancedEdition). 

Unlike traditional approaches that rely on [Mono.Cecil](https://www.mono-project.com/docs/tools+libraries/libraries/Mono.Cecil/) to provide Types filters and assertions, `ArchGuard` leverages Roslyn for analysis, making it more efficient and better suited for modern .NET development.

[Mono.Cecil](https://www.mono-project.com/docs/tools+libraries/libraries/Mono.Cecil/) has certain limitations when providing accurate information for Architecture Tests. For example, it cannot reliably determine whether a `Type` is defined as a [record](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record) or whether it has the [file](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/file) access modifier.

With `ArchGuard`, you can define and enforce architectural rules in your codebase with ease. It provides better syntax sugar and conditional grouping to make your rules more expressive and maintainable.

## Examples

``` csharp
[Fact]
public void Classes_that_interit_PublicClass_should_be_immutable()
{
    // Arrange
    var test = TypesFromMockedAssembly.All
        .That
        .Inherit<PublicClass>()
        .Should
        .BePublic();

    // Act
    var result = test.GetResult();

    // Assert
    Assert.True(result.IsSuccessful);
}
```

``` csharp
[Fact]
public void Classes_and_interfaces_that_reside_on_namespace_Public_should_be_public()
{
    // Arrange
    var test = TypesFromMockedAssembly.All
        .That
        .ResideInNamespaceContaining("Public")
        .And(types => types.AreClasses().Or.AreInterfaces())
        .Should
        .BePublic();

    // Act
    var result = test.GetResult();

    // Assert
    Assert.True(result.IsSuccessful);
}
```
