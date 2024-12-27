namespace ArchGuard.Tests;

public sealed class RecordsTests
{
    [Fact]
    public void Get_records()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreRecords()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(TypeNames.Records);
    }

    [Fact]
    public void Get_non_record_types()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;
        var nonRecordTypes = TypeNames.Types.Except(TypeNames.Records, StringComparer.Ordinal);

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreNotRecords()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(nonRecordTypes);
    }

    [Fact]
    public void Get_public_records()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreRecords()
            .And()
            .ArePublic()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(TypeNames.RecordsPublic);
    }

    [Fact]
    public void Get_internal_records()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreRecords()
            .And()
            .AreInternal()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(TypeNames.RecordsInternal);
    }

    [Fact]
    public void Get_partial_records()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;
        var partialRecords = new List<string>
        {
            TypeNames.InternalPartialRecord,
            TypeNames.PublicPartialRecord,
        };

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreRecords()
            .And()
            .ArePartial()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(partialRecords);
    }

    [Fact]
    public void Get_sealed_records()
    {
        // Arrange
        var assembly = typeof(PublicClass).Assembly;
        var sealedRecords = new List<string>
        {
            TypeNames.InternalSealedRecord,
            TypeNames.PublicSealedRecord,
        };

        // Act
        var types = Types
            .FromAssembly(assembly)
            .That()
            .AreRecords()
            .And()
            .AreSealed()
            .GetTypes()
            .GetFullNamesOrdered();

        // Assert
        types.Should().BeEquivalentTo(sealedRecords);
    }
}
