namespace ArchGuard.PublicApi.Tests
{
    using ArchGuard.Exceptions;

    public sealed class Load_types_from_sln
    {
        [Fact]
        public void Successfully_load_types_from_given_sln()
        {
            // Arrange
            var searchParameters = new SolutionSearchParameters
            {
                SolutionPath = "ArchGuard.sln",
                Preprocessor = "net9_0",
                ProjectName = "ArchGuard.MockedAssembly.Classes",
            };

            // Act
            var types = Types.InSolution(searchParameters).GetTypes();

            // Assert
            Check.That(types).HasFirstElement();
        }

        [Fact]
        public void Error_when_sln_does_not_exists()
        {
            // Arrange
            var slnPath = $"C:/{Guid.NewGuid()}";
            var searchParameters = new SolutionSearchParameters
            {
                SolutionPath = slnPath,
                Preprocessor = "net9_0",
                ProjectName = "ArchGuard.MockedAssembly.Classes",
            };

            // Act
            Action @action = () => Types.InSolution(searchParameters).GetTypes();

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
            var searchParameters = new SolutionSearchParameters
            {
                SolutionPath = "ArchGuard.sln",
                Preprocessor = "net9_0",
                ProjectName = projectName,
            };

            // Act
            Action @action = () => Types.InSolution(searchParameters).GetTypes();

            // Assert
            Check
                .ThatCode(@action)
                .Throws<ProjectNotFoundException>()
                .WhichMember(x => x.Message)
                .MatchesWildcards($"*{projectName}*");
        }
    }
}
