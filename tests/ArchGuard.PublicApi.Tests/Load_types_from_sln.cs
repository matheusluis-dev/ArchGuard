namespace ArchGuard.PublicApi.Tests
{
    using ArchGuard.Exceptions;

    public sealed class Load_types_from_sln
    {
        [Fact]
        public void Successfully_load_types_from_given_sln()
        {
            // Act
            var types = Types.InSolution("ArchGuard.sln", "ArchGuard.MockedAssembly.Classes", "net9_0").GetTypes();

            // Assert
            Check.That(types).HasFirstElement();
        }

        [Fact]
        public void Error_when_sln_does_not_exists()
        {
            // Arrage
            var slnPath = Guid.NewGuid().ToString();

            // Act
            Action @action = () => Types.InSolution(slnPath, "ArchGuard.MockedAssembly.Classes", "net9_0").GetTypes();

            // Assert
            Check
                .ThatCode(@action)
                .Throws<SolutionNotFoundException>()
                .WhichMember(x => x.Message)
                .MatchesWildcards($"*{slnPath}*");
        }

        [Fact]
        public void Error_when_project_name_is_invalid()
        {
            // Arrange
            var projectName = "It.Does.Not.Exists";

            // Act
            Action @action = () => Types.InSolution("ArchGuard.sln", projectName, "net9_0").GetTypes();

            // Assert
            Check
                .ThatCode(@action)
                .Throws<ProjectNotFoundException>()
                .WhichMember(x => x.Message)
                .MatchesWildcards($"*{projectName}*");
        }
    }
}
